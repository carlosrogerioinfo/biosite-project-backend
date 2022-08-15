using Biosite.Domain.Profiles;

namespace Biosite.Biomarkers.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(BiomarkerProfile)
            );

            return services;
        }
    }
}
