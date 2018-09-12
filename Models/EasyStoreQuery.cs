namespace eu.cdab.GraphQL_Gokhan.Models
{
    using GraphQL.Types;

    using eu.cdab.GraphQL_Gokhan.Data;

    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Category id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");

                    return categoryRepository.GetCategoryAsync(id).Result;
                }
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Product id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");

                    return productRepository.GetProductAsync(id).Result;
                }
            );
        }
    }
}