using Autofac;
using AgrotoolsMaps.Api.Interfaces;
using AgrotoolsMaps.Api.Responses;
using AgrotoolsMaps.Application.Interfaces;
using AgrotoolsMaps.Infra.CrossCutting.IoC;

namespace AgrotoolsMaps.Host
{
    public class Startup
    {
        private readonly string _assemblyName;
        private readonly string _version;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var assembly = GetType().Assembly.GetName();
            _assemblyName = assembly.Name ?? string.Empty;
            _version = assembly.Version?.ToString() ?? string.Empty;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddServiceCollections(Configuration, _assemblyName, _version);
        }

        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) 
                .AllowCredentials());
            app.AddApplicationBuilder(logger, _version);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependenciesResolveModule());
            
            builder.RegisterType<Presenter>()
                .As<IOutputPort>()
                .As<IPresenter>()
                .InstancePerLifetimeScope();
        }
    }
}