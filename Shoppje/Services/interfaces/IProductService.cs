using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        public Task<ProductModel> GetProductById(int id);
    }
}
