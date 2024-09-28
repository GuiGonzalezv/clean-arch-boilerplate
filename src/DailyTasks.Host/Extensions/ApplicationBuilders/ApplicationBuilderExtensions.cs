using AgrotoolsMaps.Host.Middleware;
using Serilog;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddApplicationBuilder(this IApplicationBuilder app,
            Microsoft.Extensions.Logging.ILogger logger, string version)
        {
            app
                .UseHttpsRedirection()
                .UseSerilogRequestLogging()
                .UseMiddleware<ErrorHandlingMiddleware>()
                .UseStaticFiles()
                .UseSwagger(version)
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoint =>
                {
                    endpoint.MapControllers();
                    endpoint.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                });

            return app;
        }
    }
}