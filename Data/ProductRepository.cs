namespace eu.cdab.GraphQL_Gokhan.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using eu.cdab.GraphQL_Gokhan.Data;
    using eu.cdab.GraphQL_Gokhan.Models;

    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

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

            _applicationDbContext.Products.AddRange(products);
            _applicationDbContext.SaveChanges();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _applicationDbContext.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _applicationDbContext.Products.Where(product => product.CategoryId == categoryId).ToListAsync();
        }
    }
}