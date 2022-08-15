using Biosite.Domain.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Biosite.Organs.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(OrganProfile)
            );

            return services;
        }
    }
}
