using Biosite.Gateway.Api.Services.Biomarker;
using Biosite.Gateway.Api.Services.Organ;
using Biosite.Gateway.Api.Services.Profile;
using System.Net.Http.Headers;

namespace Biosite.Gateway.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration = null)
        {

            var baseUrl = (configuration.GetSection("useLocal").Value.ToLower().Trim() == "true" ? "BaseUrl-Local" : "BaseUrl");

            services.AddHttpClient<BiomarkerService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection(baseUrl)["BiomarkerApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<ProfileService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection(baseUrl)["ProfileApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHttpClient<OrganService>(config =>
            {
                config.BaseAddress = new Uri(configuration.GetSection(baseUrl)["OrganApi"]);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
