using Microsoft.AspNetCore.Mvc;
using Shoppje.Services.interfaces;

namespace Shoppje.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartService _cartService;
        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public async Task< IActionResult> Add(int Id)
        {
            await _cartService.AddToCart(Id);
            return Redirect(Request.Headers["Referer"].ToString());

        }
    }
}
