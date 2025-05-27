using Shoppje.Models.ViewModels;

namespace Shoppje.Services.interfaces
{
    public interface  ICartService
    {
        public CartItemViewModel GetCartItems();

        public Task AddToCart(int productId);
        Task IncreaseQuantity(int id);
    }
}
