using Shoppje.Areas.admin.Models;
using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IBrandReposiotry
    {
        Task<bool> AddBrandAsync(BrandModel brand);
        Task DeleteBrandAsync(int id);
        Task EditBrandAsync(BrandModel brand);
        Task<IEnumerable<BrandModel>> GetAll();
        Task<BrandModel> GetBrandById(int id);
        Task<BrandModel> GetBrandBySlug(string slug);
    }
}
