using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GBO.MyAiport.EF
{
    public class MyAirportContext : DbContext
    {
        private ILogger logger;

        public DbSet<Vol> Vols { get; set; }
        public DbSet<Bagage> Bagages { get; set; }

        public MyAirportContext(DbContextOptions<MyAirportContext> options, ILogger logger) : base(options)
        {
            this.logger = logger;
            logger.LogInformation("Context initialized.");
        }

    }
}
