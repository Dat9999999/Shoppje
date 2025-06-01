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
