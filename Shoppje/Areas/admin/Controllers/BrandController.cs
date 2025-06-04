using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shoppje.Areas.admin.Models;
using Shoppje.Services.implements;
using Shoppje.Services.interfaces;

namespace Shoppje.Areas.admin.Controllers
{
    [Area("admin")]
    public class BrandController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IBrandService _brandService;
        public BrandController(ILogger<CategoryController> logger,IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            var brands = _brandService.GetAll().Result;
            _logger.LogInformation("CategoryController: Index - Categories Count: {Count}", brands.ToString());
            return View(brands);
        }
        public async Task<IActionResult> EditAsync(int id)
        {
            ViewBag.CategoryStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Display", Value = "1" },
                new SelectListItem { Text = "Hide", Value = "0" }
            };
            var Brand = await _brandService.GetBrandById(id);
            BrandEditViewModel brandEditViewModel = new BrandEditViewModel
            {
                Id = Brand.Id,
                Name = Brand.Name,
                Status = Brand.Status,
                Description = Brand.Description
            };
            return View(brandEditViewModel);
        }
        public async Task<IActionResult> EditProcessing(BrandEditViewModel brandEditViewModel)
        {
            ViewBag.CategoryStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Display", Value = "1" },
                new SelectListItem { Text = "Hide", Value = "0" }
            };
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid for brand edition: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View("Edit", brandEditViewModel); // Quay lại view với thông báo lỗi
            }

            var result = await _brandService.EditCategoryAsync(brandEditViewModel);
            if (result)
            {
                TempData["Success"] = "Brand Edited successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "some thing went wrong when trying to edit Brand";
            return View("Edit", brandEditViewModel); // Quay lại view với thông báo lỗi
        }
        public IActionResult Add()
        {
            ViewBag.BrandStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Display", Value = "1" },
                new SelectListItem { Text = "Hide", Value = "0" }
            };
            return View();
        }
        public async Task<IActionResult> AddProcessing(BrandCreateViewModel brandCreateViewModel)
        {


            ViewBag.BrandStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Display", Value = "1" },
                new SelectListItem { Text = "Hide", Value = "0" }
            };
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid for brand creation: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View("Add", brandCreateViewModel); // Quay lại view với thông báo lỗi
            }

            var result = await _brandService.AddBrandAsync(brandCreateViewModel);
            if (result)
            {
                TempData["Success"] = "Brand added successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "some thing went wrong when trying to add Brand";
            return View(brandCreateViewModel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            // Xử lý xóa sản phẩm ở đây (ví dụ: gọi service để xóa sản phẩm)

            await _brandService.DeleteBrandAsync(id);
            _logger.LogInformation("Brand with ID {Id} deleted successfully.", id);
            TempData["Success"] = "Brand deleted successfully.";
            return RedirectToAction("Index");

        }
    }
}
