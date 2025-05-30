using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<CategoryModel> GetSlugByName(string slug)
        {
            return await _categoryRepository.GetSlugByName(slug);
        }


        public Task<IEnumerable<ProductModel>> GetListProductOfSlug(string slug)
        {
            var category = _categoryRepository.GetSlugByName(slug);
            if (category == null)
            {
                return Task.FromResult(Enumerable.Empty<ProductModel>());
            }
            return _productRepository.GetListProductOfSlug(category.Result.Id);
        }

        public Task<IEnumerable<CategoryModel>> GetAll()
        {
            return Task.FromResult(_categoryRepository.GetAll().Result.AsEnumerable());
        }
    }
}
