using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GBO.MyAirport.EF
{
    /// <summary>
    /// Database context
    /// </summary>
    public class MyAirportContext : DbContext
    {
        /// <summary>
        /// DbSet of Vols
        /// </summary>
        public DbSet<Vol> Vols { get; set; } = null!;
        /// <summary>
        /// DbSet of Bagages
        /// </summary>
        public DbSet<Bagage> Bagages { get; set; } = null!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param type="DbContextOptions" name="options">Context options to initialize database connection</param>
        public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options)
        {

        }
    }
}
