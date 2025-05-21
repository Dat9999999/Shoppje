using Microsoft.AspNetCore.Mvc;

namespace Shoppje.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
