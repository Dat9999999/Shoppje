using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
    }
}
