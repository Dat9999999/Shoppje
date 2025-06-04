using Shoppje.Areas.admin.Models;
using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IBrandReposiotry
    {
        Task<bool> AddBrandAsync(BrandModel brand);
        Task<IEnumerable<BrandModel>> GetAll();
        Task<BrandModel> GetBrandBySlug(string slug);
    }
}
