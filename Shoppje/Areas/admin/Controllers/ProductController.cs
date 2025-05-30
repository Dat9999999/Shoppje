using Microsoft.AspNetCore.Mvc;
using Shoppje.Services.interfaces;

namespace Shoppje.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }
    }
}
