using AgrotoolsMaps.Host.Constants;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, string version)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v{version}/swagger.json", HostConstants.ProjectDisplayName));

            return app;
        }
    }
}