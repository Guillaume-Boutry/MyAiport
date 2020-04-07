using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using GBO.MyAiport.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

namespace GBO.MyAirport.WebApi      
{
    /// <summary>
    /// WebServer startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Read only configurations
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Dependency Injections</param>
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            services.AddDbContext<MyAirportContext>(options => options.UseSqlServer(connectionString));
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "MyAirport v1",
                    Description = "MyAirport description",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Guillaume Boutry",
                        Email = "guillaume.boutry@edu.ece.fr",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT License",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                referencedAssemblies.ToList().ForEach(assembly =>
                {
                    var path = Path.Combine(AppContext.BaseDirectory, $"{assembly.Name}.xml");
                    if (File.Exists(path))
                        c.IncludeXmlComments(path);
                });

            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <param name="env">Environment settings</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAirport v1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
