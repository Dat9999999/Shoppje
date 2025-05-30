using Microsoft.EntityFrameworkCore;
using Shoppje.data;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using System.Collections.Immutable;

namespace Shoppje.Repositories.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
            return await _context.Categories
                .ToListAsync()
                .ContinueWith(task => task.Result.AsEnumerable().ToImmutableArray());
        }

        public Task<CategoryModel> GetSlugByName(string slug)
        {
            return _context.Categories
                .FirstOrDefaultAsync(c => c.Slug == slug);
        }
    }
}
