using Shoppje.Models;
using Shoppje.Models.ViewModels;
using Shoppje.Repositories;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shoppje.Services.implements
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CartService> _logger;
        private readonly IProductRepository _productRepository;

        public CartService(IHttpContextAccessor httpContextAccessor, ILogger<CartService> logger, IProductRepository productRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task AddToCart(int productId)
        {
            ProductModel productItem = await _productRepository.GetProductById(productId);
            _logger.LogInformation("Adding product to cart: {0}", productItem.Name);
            List<CartItemModel> cartItems = _httpContextAccessor.HttpContext?.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemModel existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);
            _logger.LogInformation("Session ID: {0}", _httpContextAccessor.HttpContext.Session.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cartItems.Add(new CartItemModel
                {
                    ProductId = productId,
                    ProductName = productItem.Name,
                    Price = productItem.Price,
                    ImageUrl = productItem.Img,
                    Quantity = 1
                });
            }
            _httpContextAccessor.HttpContext.Session.SetJson("Cart", cartItems);
            _logger.LogInformation("Cart saved to session: " + JsonSerializer.Serialize(cartItems));
        }

        public Task Clear(ISession session)
        {
            session.Remove("Cart");
            _logger.LogInformation("Cart cleared from session.");
            return Task.CompletedTask;
        }

        public Task DecreaseQuantity(int id)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }
            var cartItems = session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            if (cartItems == null || !cartItems.Any())
            {
                throw new InvalidOperationException("Cart is empty.");
            }
            _logger.LogInformation("Increasing quantity for product ID {0}", id);
            var item = cartItems.FirstOrDefault(i => i.ProductId == id);
            if (item == null)
            {
                throw new InvalidOperationException("Item not found in cart.");
            }
            item.Quantity--;
            if (item.Quantity <= 0)
            {
                cartItems.Remove(item);
            }
            session.SetJson("Cart", cartItems);
            _logger.LogInformation("Increased quantity for product ID {0}. New quantity: {1}", id, item.Quantity);
            return Task.CompletedTask;
        }

        public CartItemViewModel GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }

            var cartItems = session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            var cartItemViewModel = new CartItemViewModel
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(item => item.Price * item.Quantity)
            };
            _logger.LogInformation("Total cart items : {0}",cartItems.Count());
            return cartItemViewModel;
        }

        public Task IncreaseQuantity(int id)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }
            var cartItems = session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            if (cartItems == null || !cartItems.Any())
            {
                throw new InvalidOperationException("Cart is empty.");
            }
            _logger.LogInformation("Increasing quantity for product ID {0}", id);
            var item = cartItems.FirstOrDefault(i => i.ProductId == id);
            if (item == null)
            {
                throw new InvalidOperationException("Item not found in cart.");
            }
            item.Quantity++;
            session.SetJson("Cart", cartItems);
            _logger.LogInformation("Increased quantity for product ID {0}. New quantity: {1}", id, item.Quantity);
            return Task.CompletedTask;
        }
    }
}
