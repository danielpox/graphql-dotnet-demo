namespace eu.cdab.GraphQL_Gokhan.Models
{
    using System.Linq;

    using GraphQL.Types;

    using eu.cdab.GraphQL_Gokhan.Data;

    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository)
        {
            Field(p => p.Id).Description("Product id.");
            Field(p => p.Name).Description("Product name.");
            Field(p => p.Description, nullable: true).Description("Product description.");
            Field(p => p.Price).Description("Product price.");

            Field<CategoryType>(
                "category",
                resolve: context => categoryRepository.GetCategoryAsync(context.Source.CategoryId).Result
            );
        }
    }
}