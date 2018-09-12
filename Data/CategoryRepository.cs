namespace eu.cdab.GraphQL_Gokhan.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using eu.cdab.GraphQL_Gokhan.Models;

    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

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

            _applicationDbContext.Categories.AddRange(categories);
            _applicationDbContext.SaveChanges();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _applicationDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _applicationDbContext.Categories.FindAsync(id);
        }
    }
}