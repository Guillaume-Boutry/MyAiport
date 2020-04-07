using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GBO.MyAirport.GraphQLWebApi
{
    public class MyAirportSchema : Schema
    {
        public MyAirportSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<MyAirportQuery>();
        }
    }
}