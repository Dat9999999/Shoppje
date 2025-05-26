using Shoppje.Models;
using Shoppje.Models.ViewModels;
using Shoppje.Repositories;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CartService> _logger;

        public CartService(IHttpContextAccessor httpContextAccessor, ILogger<CartService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public CartItemViewModel GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }

            var cartItems = session.GetJson<List<CartItemModel>>("CartItems") ?? new List<CartItemModel>();
            var cartItemViewModel = new CartItemViewModel
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(item => item.Price * item.Quantity)
            };
            _logger.LogInformation("Total cart items : {0}",cartItems.Count());
            return cartItemViewModel;
        }
    }
}
