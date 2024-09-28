using AgrotoolsMaps.Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextFactory<GlobalAccountDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("GlobalAccount") ?? string.Empty, x => x.UseNetTopologySuite())
                   .LogTo(s => Console.WriteLine(s))
                         .EnableDetailedErrors(true)
                         .EnableSensitiveDataLogging(true)
               );

            return services;
        }
    }
}