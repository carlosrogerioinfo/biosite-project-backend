using Biosite.Authentication.Api.Configurations;
using Biosite.Core.JwtBearer.Configurations;

namespace Biosite.Authentication.Api
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
            services.AddAutoMapperConfiguration();

            services.AddWebApiConfiguration();

            services.AddSwaggerConfiguration();

            services.AddDependencyInjectionConfiguration();

            services.AddJWTBearerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJWTBearerConfiguration();

            app.UseWebApiConfiguration(true);

            app.UseSwaggerConfiguration(env);
        }
    }
}
