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
            try
            {
                await _cartService.AddToCart(Id);
                TempData["success"] = "Product added to cart successfully!";
            }
            catch (Exception ex)
            {
                // Ghi log lỗi ra file, database hoặc hệ thống log tập trung
                _logger.LogError(ex, "Failed to add product {ProductId} to cart", Id);

                TempData["error"] = "There was a problem adding the product to the cart.";
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Increase(int Id)
        {
            try
            {
                await _cartService.IncreaseQuantity(Id);
                TempData["success"] = "Increase product successfully!";
            }
            catch (Exception ex)
            {
                // Ghi log lỗi ra file, database hoặc hệ thống log tập trung
                _logger.LogError(ex, "Failed to incresase product {ProductId}", Id);

                TempData["error"] = "There was a problem increase product";
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Decrease(int Id)
        {
            try
            {
                await _cartService.DecreaseQuantity(Id);
                TempData["success"] = "Decrease product successfully!";
            }
            catch (Exception ex)
            {
                // Ghi log lỗi ra file, database hoặc hệ thống log tập trung
                _logger.LogError(ex, "Failed to incresase product {ProductId}", Id);

                TempData["error"] = "There was a problem decrease product";
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear()
        {
            _cartService.Clear(HttpContext.Session);
            TempData["success"] = "Clear all Product to cart Sucessfully! ";
            return RedirectToAction("Index");
        }
        }
}
