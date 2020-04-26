using System;
using System.Configuration;
using GBO.MyAirport.EF;
using GBO.MyAirport.GraphQLWebApi.GraphQLTypes;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GBO.MyAirport.GraphQLWebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyAirportContext>(options =>
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                options.UseSqlServer(connectionString);
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddScoped<IServiceProvider>(c => new FuncServiceProvider(c.GetRequiredService));
            services.AddScoped<VolType>();
            services.AddScoped<BagageType>();
            services.AddScoped<MyAirportQuery>();
            services.AddScoped<MyAirportSchema>();
            services.AddGraphQL(x =>
                {
                    x.ExposeExceptions = true;
                })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddNewtonsoftJson(deserializerSettings => { }, serializerSettings => { })
                .AddDataLoader();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
            app.UseGraphQL<MyAirportSchema>();
            // Query example {
            //         vols {
            //             volID,
            //             cie,
            //             bagages {
            //                 bagageID,
            //                 classe
            //             }
            //         }
            //     }
            // Test url: https://localhost:5001/ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}