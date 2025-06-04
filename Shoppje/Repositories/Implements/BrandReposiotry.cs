using Microsoft.EntityFrameworkCore;
using Shoppje.Areas.admin.Models;
using Shoppje.data;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using System.Collections.Immutable;

namespace Shoppje.Repositories.Implements
{
    public class BrandReposiotry : IBrandReposiotry
    {
        private readonly DataContext _context;
        public BrandReposiotry(DataContext context)
        {
            _context = context;
        }

        public Task<bool> AddBrandAsync(BrandModel brandModel)
        {
            _context.Brands.Add(brandModel);
            return Task.FromResult(_context.SaveChanges() > 0);
        }
        public async Task<IEnumerable<BrandModel>> GetAll()
        {
            var brands = await _context.Brands.ToListAsync();
            return brands.ToImmutableArray();
        }

        public async Task<BrandModel> GetBrandBySlug(string slug)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(b => b.Slug == slug);
        }
    }
}
