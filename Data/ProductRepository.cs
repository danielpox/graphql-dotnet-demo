namespace eu.cdab.GraphQL_Gokhan.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using eu.cdab.GraphQL_Gokhan.Models;

    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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