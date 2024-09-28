using AgrotoolsMaps.Application.Interfaces.Mappers;
using AgrotoolsMaps.Infra.CrossCutting.Mappers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
            services.AddAutoMapper(typeof(Mapper));

            return services;
        }
    }
}
