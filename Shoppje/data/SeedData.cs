using Microsoft.EntityFrameworkCore;
using Shoppje.Models;

namespace Shoppje.data
{
    public class SeedData
    {
        public static void Seed(DataContext _context)
        {
            _context.Database.Migrate();
            if(!_context.Products.Any())
            {
                CategoryModel mac = new CategoryModel()
                {
                    Name = "Macbook",
                    slug = "macbook",

                    Status = 1,
                    Description = "Apple is the large company"
                };
                CategoryModel adnroid = new CategoryModel()
                {
                    Name = "Adnroid",
                    slug = "Adnroid",
                    Status = 1,
                    Description = "Personal computer "
                };
                BrandModel apple = new BrandModel()
                {
                    Name = "Apple",
                    slug = "apple",

                    Status = 1,
                    Description = "Apple is the large company"
                };
                BrandModel samsung = new BrandModel()
                {
                    Name = "Samsung",
                    slug = "samsung",
                    Status = 1,
                    Description = "Samsung devices and gadgets"
                };
                _context.Products.AddRange(
                    new ProductModel ()
                    {
                        Name = "Macbook Pro 16",
                        slug = "macbook-pro-16",
                        Description = "Apple Macbook Pro 16 is the best laptop in the world",
                        Price = 2000,
                        Img = "1.jpg",
                        Category = mac,
                        Brand = apple
                    },
                    new ProductModel()
                    {
                        Name = "Macbook Pro 15",
                        slug = "macbook-pro-15",
                        Description = "Apple Macbook Pro 15 is the best laptop in the world",
                        Price = 1000,
                        Img = "2.jpg",
                        Category = mac,
                        Brand = apple
                    }
                );
                _context.SaveChanges();
                }
        }
    }
}
