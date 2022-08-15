using System.Text.Json.Serialization;

namespace Biosite.Authentication.Api.Configurations
{
    public static class WebApiConfiguration
    {

        public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

            //services.AddControllers()
            //    .AddNewtonsoftJson(options =>
            //    {

            //        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //        //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //        options.SerializerSettings.Converters.Add(new StringEnumConverter());

            //    })
            //    .AddJsonOptions(p =>
            //    {
            //        p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //    });

            return services;
        }

        public static IApplicationBuilder UseWebApiConfiguration(this IApplicationBuilder app, bool useCors = false)
        {
            app.UseRouting();

            if (useCors)
            {
                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

    }
}
