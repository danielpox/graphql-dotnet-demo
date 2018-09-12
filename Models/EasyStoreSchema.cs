namespace eu.cdab.GraphQL_Gokhan.Models
{
    using System;

    using GraphQL.Types;

    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery));
        }
    }
}