using Shoppje.Models;
using System.Linq;

namespace Shoppje.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryModel> GetSlugByName(string slug);
        Task<IEnumerable<CategoryModel>> GetAll();
        Task<bool> AddCategoryAsync(CategoryModel category);
        Task DeleteProductAsync(int id);
        Task<CategoryModel> GetById(int id);
        Task<bool> EditCategoryAsync(CategoryModel category);
    }
}
