namespace eu.cdab.GraphQL_Gokhan.Models
{
    using System.Linq;

    using GraphQL.Types;

    using eu.cdab.GraphQL_Gokhan.Data;

    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(c => c.Id).Description("Category id.");
            Field(c => c.Name, nullable: true).Description("Category name.");

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetProductsByCategoryIdAsync(context.Source.Id).Result.ToList()
            );
        }
    }
}