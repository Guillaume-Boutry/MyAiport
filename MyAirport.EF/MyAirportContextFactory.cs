using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBO.MyAiport.EF
{
    class MyAirportContextFactory : IDesignTimeDbContextFactory<MyAirportContext>
    {
        public MyAirportContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>();
            optionsBuilder.UseSqlServer(@"Data Source=localhost,1433;Initial Catalog=MyAirport;User ID=croisillon;Password=Croisillon4!;");
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Debug)
                    .AddFilter("System", LogLevel.Warning);
            });
            optionsBuilder.UseLoggerFactory(loggerFactory);
            return new MyAirportContext(optionsBuilder.Options);
        }
    }
}
