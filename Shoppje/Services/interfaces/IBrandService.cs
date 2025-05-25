using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<ProductModel>> GetListProductOfSlug(string slug);
        Task<BrandModel> GetBySlug(string slug);
    }
}
