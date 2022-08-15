using Authentication.Gateway.Api.Services.Authentication;
using System.Net.Http.Headers;

namespace Authentication.Gateway.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration = null)
        {
            var baseUrl = (configuration.GetSection("useLocal").Value.ToLower().Trim() == "true" ? "BaseUrl-Local" : "BaseUrl");

            services.AddHttpClient<AuthenticationService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection(baseUrl)["AuthenticationApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}