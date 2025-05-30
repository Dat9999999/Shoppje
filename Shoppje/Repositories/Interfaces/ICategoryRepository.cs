using Shoppje.Models;
using System.Linq;

namespace Shoppje.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryModel> GetSlugByName(string slug);
        Task<IEnumerable<CategoryModel>> GetAll();
    }
}
