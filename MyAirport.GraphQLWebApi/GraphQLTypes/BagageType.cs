using GBO.MyAiport.EF;
using GraphQL.Types;

namespace GBO.MyAirport.GraphQLWebApi.GraphQLTypes
{
    public sealed class BagageType : ObjectGraphType<Bagage>
    {
        public BagageType() : base()
        {

            Field(x => x.BagageID).Description("Bagage Id");
            Field(x => x.Classe);
            Field(x => x.Escale);
            Field(x => x.Prioritaire, type: typeof(BooleanGraphType), nullable: true);
            Field(x => x.Ssur);
            Field(x => x.Sta);
            Field(x => x.CodeIata);
            Field(x => x.DateCreation);
            Field(x => x.Destination).Description("Destination");
            Field(name: "Vol", type: typeof(VolType), resolve: context => context.Source.Vol);
            
        }
    }
}