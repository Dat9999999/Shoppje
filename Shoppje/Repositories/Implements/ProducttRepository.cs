using Microsoft.EntityFrameworkCore;
using Shoppje.data;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;

namespace Shoppje.Repositories.Implements
{
    public class ProducttRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProducttRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
