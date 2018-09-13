namespace eu.cdab.GraphQL_Gokhan.Models
{
    using System;

    using GraphQL;

    using GraphQL.Types;

    public class EasyStoreSchema : Schema
    {
        public EasyStoreSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<EasyStoreQuery>();
        }
    }
}