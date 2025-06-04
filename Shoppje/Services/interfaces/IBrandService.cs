using Shoppje.Areas.admin.Models;
using Shoppje.Models;
using System.Collections;

namespace Shoppje.Services.interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<ProductModel>> GetListProductOfSlug(string slug);
        Task<BrandModel> GetBySlug(string slug);
        Task<IEnumerable> GetAll();
        Task<bool> AddBrandAsync(BrandCreateViewModel brandCreateViewModel);
        Task DeleteBrandAsync(int id);
    }
}
