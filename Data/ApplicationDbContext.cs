namespace eu.cdab.GraphQL_Gokhan.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using eu.cdab.GraphQL_Gokhan.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class ApplicationDatabaseInitialiser
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                await applicationDbContext.Database.EnsureDeletedAsync();
                await applicationDbContext.Database.EnsureCreatedAsync();

                var categories = new List<Category>{
                    new Category()
                    {
                        Name = "Computers"
                    },
                    new Category()
                    {
                        Name = "Mobile Phones"
                    }
                };

                await applicationDbContext.Categories.AddRangeAsync(categories);

                var products = new List<Product>{
                    new Product()
                    {
                        CategoryId = 1,
                        Name = "Apple Macbook Pro 2016",
                        Description = "Touchbar, 3.2 GHz",
                        Price = 5000
                    },
                    new Product()
                    {
                        CategoryId = 1,
                        Name = "Apple Macbook Air",
                        Description = "2.3 GHz 8 GB RAM",
                        Price = 2000
                    },
                    new Product()
                    {
                        CategoryId = 1,
                        Name = "Dell XPS 13",
                        Description = "3.3 GHz 12 GB RAM",
                        Price = 4000
                    },
                };

                await applicationDbContext.Products.AddRangeAsync(products);

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}