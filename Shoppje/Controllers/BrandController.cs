using Microsoft.AspNetCore.Mvc;
using Shoppje.Services.interfaces;

namespace Shoppje.Controllers
{
    public class BrandController : Controller
    {
        private readonly ILogger<BrandController> _logger;
        private readonly IBrandService _brandService;
        public BrandController(ILogger<BrandController> logger, IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }
        public IActionResult Index([FromQuery] String Slug)
        {
            var products = _brandService.GetListProductOfSlug(Slug).Result;
            _logger.LogInformation("BrandController: Index - Slug: {Slug}, Products Count: {Count}", Slug, products.Count());
            return View(products);
        }
    }
}
