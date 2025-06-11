using Shoppje.Models.ViewModels;

namespace Shoppje.Services.interfaces
{
    public interface  ICartService
    {
        public CartItemViewModel GetCartItems();

        public Task AddToCart(int productId);
        Task IncreaseQuantity(int id);
        Task DecreaseQuantity(int id);
        Task Clear(ISession session);
        Task Checkout(string? name, CartItemViewModel cart);
    }
}
