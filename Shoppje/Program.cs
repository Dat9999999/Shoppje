using Microsoft.EntityFrameworkCore;
using Shoppje.data;
using Shoppje.Repositories.Implements;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.implements;
using Shoppje.Services.interfaces;

namespace Shoppje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.IsEssential = true; // Make the session cookie essential
            });
            builder.Services.AddHttpContextAccessor();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


            builder.Services.AddDbContext<Shoppje.data.DataContext>(options =>
                options.UseSqlServer(connectionString));

            //Dependency Injection for repository 
            builder.Services.AddScoped<IProductRepository, ProducttRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IBrandReposiotry, BrandReposiotry>();



            //DI for services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<ICartService, CartService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<Shoppje.data.DataContext>();
            SeedData.Seed(context);

            app.Run();
        }
    }
}
