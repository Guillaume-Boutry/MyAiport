using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GBO.MyAiport.EF
{
    public class MyAirportContext : DbContext
    {
        public DbSet<Vol> Vols { get; set; } = null!;
        public DbSet<Bagage> Bagages { get; set; } = null!;

        public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options)
        {

        }
 

    }
}
