using Biosite.Core.Commands.Response;
using Biosite.Core.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Biosite.Core.JwtBearerToken.Service
{
    public class JwtService: IJwtService
    {
        public string GenerateToken(UserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSettings.SECRET_KEY);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
            };

            claims.Add(new Claim(ClaimTypes.Role, user.PlanResponse.Name));
            //claims.AddRange(user.UserPlan.Select(p => new Claim(ClaimTypes.Role, p.Plan.Name)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = TokenSettings.ISSUER,
                Audience = TokenSettings.AUDIENCE,
                Expires = DateTime.UtcNow.AddMinutes(TokenSettings.TIME_VALIDATION_TOKEN),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
