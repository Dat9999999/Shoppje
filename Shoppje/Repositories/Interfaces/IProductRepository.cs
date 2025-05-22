using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> GetProductsAsync();
    }
}
