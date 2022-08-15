using Biosite.Biomarkers.Api.Commands.Handlers;
using Biosite.Core;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Contexts;
using Biosite.Infrastructure.Repositories;
using Biosite.Infrastructure.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Biosite.Biomarkers.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<BiositeDataContext>(opt =>
            {
                opt.UseSqlServer(Runtime.ConnectionString);
                //opt.EnableSensitiveDataLogging();
                //opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

            }, ServiceLifetime.Scoped);

            services.AddScoped<IUow, Uow>();

            services.AddScoped<IBiomarkerRepository, BiomarkerRepository>();
            services.AddScoped<BiomarkerCommandHandler, BiomarkerCommandHandler>();

            return services;
        }
    }
}
