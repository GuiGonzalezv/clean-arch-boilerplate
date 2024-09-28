using System;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection services, IConfiguration configuration, string assemblyName, string version)
        {

            services
                .AddMvcService()
                .AddAutoMapper()
                .AddSwagger(assemblyName, version)
                .AddEntityDbContext(configuration)
                .AddCors(o => o.AddPolicy("AllowOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(8000));
                }));

            return services;
        }
    }
}
