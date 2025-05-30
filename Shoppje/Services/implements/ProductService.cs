using Shoppje.Areas.admin.Models;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<bool> AddProductAsync(ProductCreateViewModel productCreateViewModel)
        {
            try
            {
                // Xử lý upload ảnh
                if (productCreateViewModel.ImageUpload != null && productCreateViewModel.ImageUpload.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(productCreateViewModel.ImageUpload.FileName);
                    var extension = Path.GetExtension(productCreateViewModel.ImageUpload.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await productCreateViewModel.ImageUpload.CopyToAsync(stream);
                    }
                await _productRepository.AddProductAsync(new ProductModel
                {
                    Name = productCreateViewModel.Name,
                    Price = productCreateViewModel.Price,
                    Description = productCreateViewModel.Description,
                    Img = newFileName,
                    slug = productCreateViewModel.slug,
                    CategoryId = productCreateViewModel.CategoryId,
                    BrandId = productCreateViewModel.BrandId
                });
                return true;
                }
                throw new InvalidOperationException("Image upload is required.");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                _logger.LogError(ex, "Lỗi khi thêm sản phẩm");
                return false;
            }
        }

        public Task<ProductModel> GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return product;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
