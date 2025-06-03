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

        public async Task<bool> AddCategoryAsync(CategoryModel category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory != null)
            {
                _context.Categories.Remove(existingCategory);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> EditCategoryAsync(CategoryModel category)
        {
            try
            {
                _context.Categories.Update(category);
                return Task.FromResult(_context.SaveChanges() > 0);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.AsEnumerable().ToImmutableArray();
        }

        public Task<CategoryModel> GetById(int id)
        {
            return _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<CategoryModel> GetSlugByName(string slug)
        {
            return _context.Categories.FirstOrDefaultAsync(c => c.Slug == slug);
        }
    }
}
