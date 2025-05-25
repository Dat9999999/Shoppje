using Microsoft.AspNetCore.Mvc;
using Shoppje.Services.interfaces;

namespace Shoppje.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }
        public IActionResult Index([FromQuery] String Slug)
        {
            var products = _categoryService.GetListProductOfSlug(Slug).Result;
            _logger.LogInformation("CategoryController: Index - Slug: {Slug}, Products Count: {Count}", Slug, products.Count());
            return View(products);
        }
    }
}
