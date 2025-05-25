using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;

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
    }
}
