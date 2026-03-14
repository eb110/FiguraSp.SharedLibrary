using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiguraSp.SharedLibrary.DependencyInjection
{
    public static class SharedService
    {
        public static IServiceCollection AddSharedServies<TContext>
        (this IServiceCollection services, IConfiguration config) where TContext : DbContext
        {
            SqlServerService.AddSqlServerService<TContext>(services, config);

            return services;
        }
    }
}
