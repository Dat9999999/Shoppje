using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IBrandReposiotry
    {
        Task<IEnumerable<BrandModel>> GetAll();
        Task<BrandModel> GetBrandBySlug(string slug);
    }
}
