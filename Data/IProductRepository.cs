namespace eu.cdab.GraphQL_Gokhan.Data
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using eu.cdab.GraphQL_Gokhan.Models;

    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId);
        Task<Product> GetProductAsync(int id);
    }
}