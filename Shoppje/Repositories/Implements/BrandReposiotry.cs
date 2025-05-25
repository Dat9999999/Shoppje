using Microsoft.EntityFrameworkCore;
using Shoppje.data;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;

namespace Shoppje.Repositories.Implements
{
    public class BrandReposiotry : IBrandReposiotry
    {
        private readonly DataContext _context;
        public BrandReposiotry(DataContext context)
        {
            _context = context;
        }
        public async Task<BrandModel> GetBrandBySlug(string slug)
        {
            return await _context.Brands
                .FirstOrDefaultAsync(b => b.Slug == slug);
        }
    }
}
