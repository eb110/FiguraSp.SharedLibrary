using FiguraSp.SharedLibrary.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiguraSp.SharedLibrary.DependencyInjection
{
    public static class SharedService
    {
        public static IServiceCollection AddSharedSqlService<TContext>
        (this IServiceCollection services, IConfiguration config) where TContext : DbContext
        {
            SqlServerService.AddSqlServerService<TContext>(services, config);

            return services;
        }

        public static IServiceCollection AddJwtSharedService
        (this IServiceCollection services, IConfiguration config)
        {
            JwtAuthenticationScheme.AddJwtConfigurationAndValidation(services, config);

            return services;
        }

        public static IServiceCollection AddSharedPolicyService
            (this IServiceCollection services, IConfiguration config)
        {
            SharedPolicyService.AddSharedPolicy(services, config);

            return services;
        }

        public static IApplicationBuilder UseSharedGatewary(this IApplicationBuilder app)
        {
            //register middleware to block all outside API calls
            app.UseMiddleware<SharedGateway>();

            return app;
        }
    }
}
