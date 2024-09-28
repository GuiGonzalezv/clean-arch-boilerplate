
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using AgrotoolsMaps.Application.Interfaces.LogService;
using AgrotoolsMaps.Infra.CrossCutting.LogService;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcServiceCollectionExtensions
    {
        public static IServiceCollection AddMvcService(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(opt => opt.Configure());

            services
                .AddResponseCompression(opt =>
                {
                    opt.Providers.Add<BrotliCompressionProvider>();
                    opt.EnableForHttps = true;

                });

            services.AddHttpContextAccessor();

            services.AddScoped(typeof(ILog<>), typeof(Log<>));

            return services;
        }

        private static void Configure(this MvcNewtonsoftJsonOptions opt)
        {
            opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        }
    }
}