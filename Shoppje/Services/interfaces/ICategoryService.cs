using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface ICategoryService
    {
       public Task<IEnumerable<ProductModel>> GetListProductOfSlug(string slug);
        public Task<CategoryModel> GetSlugByName(string slug);
        public Task<IEnumerable<CategoryModel>> GetAll();
    }
}
