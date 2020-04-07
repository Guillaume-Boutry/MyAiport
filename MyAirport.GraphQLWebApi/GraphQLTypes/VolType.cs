using System;
using System.Diagnostics;
using System.Linq;
using GBO.MyAiport.EF;
using GraphQL.Types;


namespace GBO.MyAirport.GraphQLWebApi.GraphQLTypes
{
    public class VolType : ObjectGraphType<Vol>
    {
        public VolType() : base()
        {
            Field(x => x.VolID).Description("Vol ID");
            Field(x => x.Cie);
            Field(x => x.Des);
            Field(x => x.Dhc, type: typeof(DateGraphType), nullable: true);
            Field(x => x.Imm);
            Field(x => x.Lig);
            Field(x => x.Pax, type: typeof(ShortGraphType), nullable: true);
            Field(x => x.Pkg);
            Field(name: "Bagages", type: typeof(ListGraphType<BagageType>), resolve: context => context.Source.Bagages);
        }
    }
}