using App.Api.Attributes;
using App.Api.Swagger.Examples;
using Infra.ApplicationServices;
using Infra.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.IO;
using System.Text.Json.Serialization;

namespace App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccessLayer(Configuration.GetConnectionString("Warehousing"));
            services.AddApplicationServices();

            services.AddControllers(opt => opt.Filters.Add<AppExceptionFilterAttribute>())
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Communere - Product API",
                    Version = "v1"
                });
                c.ExampleFilters();

                var documentPath = Path.Combine(Directory.GetCurrentDirectory(), "App.Api.xml");
                c.IncludeXmlComments(documentPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<CreateProductCommandExample>();

            services.AddCors();

            services.AddRouting(opt => opt.LowercaseUrls = true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.Api v1");
                c.InjectStylesheet("/swagger-ui/swagger.min.css");
                c.InjectJavascript("/swagger-ui/swagger.min.js");
            });

            app.UseDatabase();

            app.UseFileServer();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
