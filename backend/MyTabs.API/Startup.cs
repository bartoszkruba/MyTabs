using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyTabs.API.Data;
using MyTabs.API.Options;
using Newtonsoft.Json.Serialization;

namespace MyTabs.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var envVariables = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build()
                .AsEnumerable()
                .ToList();

            var databaseServer = envVariables.Find(x => x.Key == "DatabaseServer").Value;
            var databaseName = envVariables.Find(x => x.Key == "DatabaseName").Value;
            var databaseId = envVariables.Find(x => x.Key == "DatabaseID").Value;
            var databasePassword = envVariables.Find(x => x.Key == "DatabasePassword").Value;
            var connectionString = string.Format(Configuration.GetConnectionString("MyTabsConnection"),
                databaseServer, databaseName, databaseId, databasePassword);

            services.AddCors(c => c.AddPolicy("AllowOrigin", options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            }));
            services.AddDbContext<MyTabsContext>(opt => opt.UseSqlServer(connectionString));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                .AddNewtonsoftJson(s =>
                {
                    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddScoped<IUsersRepo, SqlUsersRepo>();

            services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "MyTabs API",
                        Description = "Simple .NET REST API created for learning purposes.",
                        Contact = new OpenApiContact
                        {
                            Name = "Bartosz Kruba",
                            Email = "bartosz.kruba@gmail.com"
                        }
                    });

                    // Set comments path for the Swagger Json and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    x.IncludeXmlComments(xmlPath);
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowOrigin");
            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(options => options.RouteTemplate = swaggerOptions.JsonRoute);
            app.UseSwaggerUI(options => options.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}