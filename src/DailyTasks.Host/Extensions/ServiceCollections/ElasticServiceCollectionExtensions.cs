using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm.MongoDb;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ElasticServiceCollectionExtensions
    {
        public static IServiceCollection AddElasticApm(this IServiceCollection services)
        {
            services.AddElasticApm(new HttpDiagnosticsSubscriber(), new EfCoreDiagnosticsSubscriber(), new MongoDbDiagnosticsSubscriber());
            return services;
        }
    }
}
