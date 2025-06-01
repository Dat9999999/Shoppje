using Microsoft.EntityFrameworkCore;
using Shoppje.data;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;

namespace Shoppje.Repositories.Implements
{
    public class ProducttRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<ProducttRepository> _logger;
        public ProducttRepository(DataContext context, ILogger<ProducttRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task AddProductAsync(ProductModel productModel)
        {
            _context.Products.Add(productModel);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();
            }
        }

        public Task EditProductAsync(ProductModel productModel)
        {
            var existingProduct = _context.Products.Find(productModel.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = productModel.Name;
                existingProduct.Price = productModel.Price;
                existingProduct.Description = productModel.Description;
                existingProduct.Img = productModel.Img;
                existingProduct.slug = productModel.slug;
                existingProduct.CategoryId = productModel.CategoryId;
                existingProduct.BrandId = productModel.BrandId;
                return _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogWarning("Product with ID {Id} not found for editing.", productModel.Id);
                throw new KeyNotFoundException($"Product with ID {productModel.Id} not found.");
            }
        }

        public Task<IEnumerable<ProductModel>> GetListProductOfSlug(int CategoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == CategoryId)
                .ToListAsync()
                .ContinueWith(task => (IEnumerable<ProductModel>)task.Result);
        }

        public Task<ProductModel> GetProductById(int id)
        {
            return _context.Products
                   .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ProductModel>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
