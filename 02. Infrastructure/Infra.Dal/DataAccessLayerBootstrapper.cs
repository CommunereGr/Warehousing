using Core.DomainModel.ProductAggregate.Data;
using Core.DomainModel.ProductAggregate.Entities;
using Infra.Dal.ProductAggregate;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Infra.Dal
{
    public static class DataAccessLayerBootstrapper
    {
        public static void AddDataAccessLayer(this IServiceCollection services, string connectionString)
        {
            services.AddMemoryCache();
            services.AddDbContext<AppDbContext>(
                opt => opt.UseSqlServer(connectionString)
            );

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void UseDatabase(this IApplicationBuilder app)
        {
            try
            {
                using var scope = app.ApplicationServices.CreateScope();
                using var context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.Migrate();

                if (!context.Products.Any())
                {
                    SeedData(context);
                    context.SaveChanges();
                }
            }
            catch
            { }
        }

        private static void SeedData(AppDbContext context)
        {
            context.Products.AddRange(
                Product.Create("Blue Jeans", 20, 17),
                Product.Create("Puma Shows", 52, 12),
                Product.Create("Brown Gloves", 20, 3),
                Product.Create("Shirt", 10, 23),
                Product.Create("Jumper", 4, 42)
            );
        }
    }
}
