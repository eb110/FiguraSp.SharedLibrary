using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiguraSp.SharedLibrary.DependencyInjection
{
    public static class SqlServerService
    {
        public static IServiceCollection AddSqlServerService<TContext>(this IServiceCollection services, IConfiguration config) where TContext : DbContext
        {
            // Add generic db context
            services.AddDbContext<TContext>(option => option.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
