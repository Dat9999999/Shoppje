using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shoppje.Areas.admin.Models;
using Shoppje.Services.implements;
using Shoppje.Services.interfaces;

namespace Shoppje.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll().Result;
            _logger.LogInformation("CategoryController: Index - Categories Count: {Count}", categories.Count());
            return View(categories);
        }
        public IActionResult Add()
        {
            ViewBag.CategoryStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Display", Value = "1" },
                new SelectListItem { Text = "Hide", Value = "0" }
            };
            return View();
        }
        public async Task<IActionResult> AddProcessing(CategoryCreateViewModel categoryCreateViewModel)
        {


            ViewBag.CategoryStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Display", Value = "1" },
                new SelectListItem { Text = "Hide", Value = "0" }
            };
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid for product creation: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View("Add", categoryCreateViewModel); // Quay lại view với thông báo lỗi
            }

            var result = await _categoryService.AddCategoryAsync(categoryCreateViewModel);
            if (result)
            {
                TempData["Success"] = "Category added successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "some thing went wrong when trying to add category";
            return View(categoryCreateViewModel);
        }
        public async Task<IActionResult> Delete(string name)
        {
            var categoryService = await _categoryService.GetSlugByName(name);
            if (categoryService == null)
            {
                _logger.LogWarning("categoryService with name {name} not found for deletion.", name);
                return NotFound();
            }
            // Xử lý xóa sản phẩm ở đây (ví dụ: gọi service để xóa sản phẩm)
            await _categoryService.DeleteProductAsync(categoryService.Id);
            _logger.LogInformation("Product with name {name} deleted successfully.", name);
            return RedirectToAction("Index");
        }
    }
}
