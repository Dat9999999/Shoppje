using Shoppje.Areas.admin.Models;
using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface ICategoryService
    {
       public Task<IEnumerable<ProductModel>> GetListProductOfSlug(string slug);
        public Task<CategoryModel> GetSlugByName(string slug);
        public Task<IEnumerable<CategoryModel>> GetAll();
        Task<bool> AddCategoryAsync(CategoryCreateViewModel categoryCreateViewModel);
        Task DeleteProductAsync(int id);
    }
}
