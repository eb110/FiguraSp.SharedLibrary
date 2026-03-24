using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiguraSp.SharedLibrary.DependencyInjection
{
    public static class SharedPolicyService
    {
        public static IServiceCollection AddSharedPolicy(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthorization(options =>
            {
                var claim = config["Claim:DefaultClaim"]!;
                var key = config["Claim:RequiredKey"]!;
                options.AddPolicy(claim, policy => policy.RequireClaim(key));
            });

            return services;
        }
    }
}
