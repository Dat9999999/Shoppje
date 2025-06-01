using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using Shoppje.Areas.admin.Models;
using Shoppje.Models;
using Shoppje.Services.implements;
using Shoppje.Services.interfaces;

namespace Shoppje.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public ProductController(ILogger<ProductController> logger, IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found for deletion.", id);
                return NotFound();
            }
            // Xử lý xóa sản phẩm ở đây (ví dụ: gọi service để xóa sản phẩm)
             await _productService.DeleteProductAsync(id);
            _logger.LogInformation("Product with ID {Id} deleted successfully.", id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _brandService.GetAll(), "Id", "Name");
            return View();
        }
        public async Task<IActionResult> AddProcessing(ProductCreateViewModel productCreateViewModel)
        {


            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), "Id", "Name");
            ViewBag.Brands = new SelectList(await _brandService.GetAll(), "Id", "Name");
            
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid for product creation: {Errors}", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View("Add", productCreateViewModel); // Quay lại view với thông báo lỗi
            }

            var result = await _productService.AddProductAsync(productCreateViewModel);
            if (result)
                return RedirectToAction("Index");

            ViewBag.ErrorMessage = "Có lỗi xảy ra khi thêm sản phẩm.";
            return View(productCreateViewModel);
        }
    }
}
