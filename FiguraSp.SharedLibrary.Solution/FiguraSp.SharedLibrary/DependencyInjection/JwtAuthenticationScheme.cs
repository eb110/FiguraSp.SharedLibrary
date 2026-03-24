using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FiguraSp.SharedLibrary.DependencyInjection
{
    public static class JwtAuthenticationScheme
    {
        public static IServiceCollection AddJwtConfigurationAndValidation(this IServiceCollection services, IConfiguration config)
        {
            var key = Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]!);
            var tokenValidationParams = new TokenValidationParameters
            {
                //encryption part of the token is added by us
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = config["Jwt:Issuer"],
                ValidateIssuer = true,
                ValidAudience = config["Jwt:Audience"],
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
                //RequireExpirationTime = false
            };
            //singleton => its value stays the same for the entire life of the app
            services.AddSingleton(tokenValidationParams);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    //if the first fails
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("Bearer", options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParams;
                });

            return services;
        }
    }
}
