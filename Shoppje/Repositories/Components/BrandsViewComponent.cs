using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppje.data;

namespace Shoppje.Repositories.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public BrandsViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Brands = await _context.Brands.ToListAsync();
            return View(Brands);
        }
    }
}
