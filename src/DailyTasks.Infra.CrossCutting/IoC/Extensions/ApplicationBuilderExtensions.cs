using Autofac;
using AgrotoolsMaps.Application.Interfaces;

namespace AgrotoolsMaps.Infra.CrossCutting.IoC.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static ContainerBuilder RegisterApplicationDependencies(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IOutputPort).Assembly)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }
    }
}