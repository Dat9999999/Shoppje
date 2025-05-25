using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IBrandReposiotry
    {
        Task<BrandModel> GetBrandBySlug(string slug);
    }
}
