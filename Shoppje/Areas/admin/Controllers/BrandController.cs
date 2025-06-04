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
        //public async Task<IActionResult> EditAsync(int id)
        //{
        //    ViewBag.CategoryStatus = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Display", Value = "1" },
        //        new SelectListItem { Text = "Hide", Value = "0" }
        //    };
        //    var Brand = await _categoryService.GetById(id);
        //    if (Brand == null)
        //    {
        //        _logger.LogWarning("Brand with ID {Id} not found for editing.", id);
        //        return NotFound();
        //    }
        //    return View(Brand);
        //}
        //public async Task<IActionResult> EditProcessing(CategoryEditViewModel categoryEditViewModel)
        //{
        //    ViewBag.CategoryStatus = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Display", Value = "1" },
        //        new SelectListItem { Text = "Hide", Value = "0" }
        //    };
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogWarning("Model state is invalid for product edition: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        //        return View("Edit", categoryEditViewModel); // Quay lại view với thông báo lỗi
        //    }

        //    var result = await _categoryService.EditCategoryAsync(categoryEditViewModel);
        //    if (result)
        //    {
        //        TempData["Success"] = "Brand Edited successfully.";
        //        return RedirectToAction("Index");
        //    }
        //    TempData["error"] = "some thing went wrong when trying to edit Brand";
        //    return View(categoryEditViewModel);
        //}
        //public IActionResult Add()
        //{
        //    ViewBag.CategoryStatus = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Display", Value = "1" },
        //        new SelectListItem { Text = "Hide", Value = "0" }
        //    };
        //    return View();
        //}
        //public async Task<IActionResult> AddProcessing(CategoryCreateViewModel categoryCreateViewModel)
        //{


        //    ViewBag.CategoryStatus = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Display", Value = "1" },
        //        new SelectListItem { Text = "Hide", Value = "0" }
        //    };
        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogWarning("Model state is invalid for product creation: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        //        return View("Add", categoryCreateViewModel); // Quay lại view với thông báo lỗi
        //    }

        //    var result = await _categoryService.AddCategoryAsync(categoryCreateViewModel);
        //    if (result)
        //    {
        //        TempData["Success"] = "Brand added successfully.";
        //        return RedirectToAction("Index");
        //    }
        //    TempData["error"] = "some thing went wrong when trying to add Brand";
        //    return View(categoryCreateViewModel);
        //}
        //public async Task<IActionResult> Delete(string name)
        //{
        //    var product = await _productService.GetProductById(id);
        //    if (product == null)
        //    {
        //        _logger.LogWarning("Product with ID {Id} not found for deletion.", id);
        //        return NotFound();
        //    }
        //    // Xử lý xóa sản phẩm ở đây (ví dụ: gọi service để xóa sản phẩm)
        //    await _productService.DeleteProductAsync(id);
        //    _logger.LogInformation("Product with ID {Id} deleted successfully.", id);
        //    return RedirectToAction("Index");

        //}
    }
}
