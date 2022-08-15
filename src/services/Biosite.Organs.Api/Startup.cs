using Biosite.Core.JwtBearer.Configurations;
using Biosite.Organs.Api.Configurations;

namespace Biosite.Organs.Api
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
