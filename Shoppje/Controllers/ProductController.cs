using Microsoft.AspNetCore.Mvc;
using Shoppje.Services.interfaces;

namespace Shoppje.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            
            var product = _productService.GetProductById(id).Result;
            if(product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found", id);
                return NotFound();
            }
            _logger.LogInformation("Retrieved product with ID {Id}", id);
            return View(product);
            
        }
    }
}
