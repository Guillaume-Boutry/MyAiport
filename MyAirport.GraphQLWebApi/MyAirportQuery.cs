using System.Linq;
using GBO.MyAiport.EF;
using GBO.MyAirport.GraphQLWebApi.GraphQLTypes;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GBO.MyAirport.GraphQLWebApi
{
public class MyAirportQuery : ObjectGraphType
    {
        public MyAirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<VolType>>(
                "vols",
                resolve: context => db.Vols.Include(v => v.Bagages).ToList());
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.Include(b => b.Vol).ToList());
        }
    }

}