using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Authentication.Gateway.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api Gateway Authentication",
                    Description = "Authentication gateway for biological medicine project.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Biosite Health",
                        Email = "api@biosite.com",
                        Url = new Uri("http://biosite.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Biosite License",
                        Url = new Uri("http://biosite.com")
                    }
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
            else
            {
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            return app;
        }

    }
}
