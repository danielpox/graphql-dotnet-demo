namespace eu.cdab.GraphQL_Gokhan.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using eu.cdab.GraphQL_Gokhan.Models;

    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>{
                new Category()
                {
                    Id = 1,
                    Name = "Computers"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Mobile Phones"
                }
            };
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(category => category.Id == id));
        }
    }
}