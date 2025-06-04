using Shoppje.Areas.admin.Models;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;
using System.Collections;

namespace Shoppje.Services.implements
{
    public class BrandService : IBrandService
    {
        private readonly IBrandReposiotry _brandReposiotry;
        private readonly IProductRepository _productRepository;
        public BrandService(IBrandReposiotry brandReposiotry, IProductRepository productRepository)
        {
            _brandReposiotry = brandReposiotry;
            _productRepository = productRepository;
        }
        public Task<IEnumerable<ProductModel>> GetListProductOfSlug(string Slug)
        {
            var brand = _brandReposiotry.GetBrandBySlug(Slug);
            if (brand == null)
            {
                return Task.FromResult(Enumerable.Empty<ProductModel>());
            }
            return _productRepository.GetListProductOfSlug(brand.Result.Id);
        }

        public Task<BrandModel> GetBySlug(string Slug)
        {
            return _brandReposiotry.GetBrandBySlug(Slug);
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _brandReposiotry.GetAll();
        }

        public Task<bool> AddBrandAsync(BrandCreateViewModel brandCreateViewModel)
        {
            var brand = new BrandModel
            {
                Name = brandCreateViewModel.Name,
                Slug = brandCreateViewModel.Name.ToLower().Replace(" ", "-"),
                Status = brandCreateViewModel.Status,
                Description = brandCreateViewModel.Description
            };
            return _brandReposiotry.AddBrandAsync(brand);
        }
    }
}
