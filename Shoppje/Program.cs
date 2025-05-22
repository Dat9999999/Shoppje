using Microsoft.EntityFrameworkCore;
using Shoppje.data;
using Shoppje.Repositories.Implements;
using Shoppje.Repositories.Interfaces;

namespace Shoppje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<Shoppje.data.DataContext>(options =>
                options.UseSqlServer(connectionString));

            //Dependency Injection for repository 
            builder.Services.AddScoped<IProductRepository, ProducttRepository>();

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
