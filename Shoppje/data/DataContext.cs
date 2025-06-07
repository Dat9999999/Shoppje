using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shoppje.Models;

namespace Shoppje.data
{
    public class DataContext : IdentityDbContext<AppUserModel> // Correct the typo in 'IndetityDbContext'
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Shoppje.Models.CategoryModel> Categories { get; set; }
        public DbSet<Shoppje.Models.ProductModel> Products { get; set; }
        public DbSet<Shoppje.Models.BrandModel> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
