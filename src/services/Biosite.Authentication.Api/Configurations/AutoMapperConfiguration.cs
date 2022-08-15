using Biosite.Domain.Profiles;

namespace Biosite.Authentication.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(PlanProfile),
                typeof(AreaProfile),
                typeof(UserProfile)
            );

            return services;
        }
    }
}
