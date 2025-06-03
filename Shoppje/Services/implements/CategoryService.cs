using Shoppje.Areas.admin.Models;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _logger = logger;
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

        public Task<bool> AddCategoryAsync(CategoryCreateViewModel categoryCreateViewModel)
        {
            categoryCreateViewModel.Slug = categoryCreateViewModel.Name.ToLower().Replace(" ", "-");
            var category = new CategoryModel
            {
                Name = categoryCreateViewModel.Name,
                Description = categoryCreateViewModel.Description,
                Slug = categoryCreateViewModel.Slug,
                Status = categoryCreateViewModel.Status
            };
            return _categoryRepository.AddCategoryAsync(category);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _categoryRepository.DeleteProductAsync(id);
        }

        public Task<CategoryModel> GetById(int id)
        {
            var cat = _categoryRepository.GetById(id);
            if (cat == null)
            {
                _logger.LogWarning($"Category with ID {id} not found.");
                return Task.FromResult<CategoryModel>(null);
            }
            return Task.FromResult(cat.Result);
        }

        public Task<bool> EditCategoryAsync(CategoryEditViewModel categoryEditViewModel)
        {
            var category = new CategoryModel
            {
                Id = categoryEditViewModel.Id,
                Name = categoryEditViewModel.Name,
                Description = categoryEditViewModel.Description,
                Slug = categoryEditViewModel.Name.ToLower().Replace(" ", "-"),
                Status = categoryEditViewModel.Status
            };
            return _categoryRepository.EditCategoryAsync(category); // Assuming AddCategoryAsync can also handle updates, otherwise implement an Update method in the repository.
        }
    }
}
