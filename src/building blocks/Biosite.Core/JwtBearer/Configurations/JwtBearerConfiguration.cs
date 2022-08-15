using Biosite.Core.JwtBearerToken.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Biosite.Core.JwtBearer.Configurations
{
    public static class JwtBearerConfiguration
    {
        public static IServiceCollection AddJWTBearerConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IJwtService, JwtService>();

            var key = Encoding.ASCII.GetBytes(TokenSettings.SECRET_KEY);

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = TokenSettings.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = TokenSettings.AUDIENCE,
                    ValidateLifetime = true
                };

            });

            return services;
        }

        public static IApplicationBuilder UseJWTBearerConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
