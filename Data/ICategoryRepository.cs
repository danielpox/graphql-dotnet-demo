namespace eu.cdab.GraphQL_Gokhan.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using eu.cdab.GraphQL_Gokhan.Models;

    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
    }
}