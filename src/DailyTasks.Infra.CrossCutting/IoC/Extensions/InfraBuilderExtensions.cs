using Autofac;
using System.Linq;
using AgrotoolsMaps.Infra.EntityFramework.Repository;

namespace AgrotoolsMaps.Infra.CrossCutting.IoC.Extensions
{
    public static class InfraBuilderExtensions
    {
        public static ContainerBuilder RegisterInfraEntityDependencies(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(Repository<,,>).Assembly)
                .Where(w => w.BaseType.IsGenericType &&
                            w.BaseType.GetGenericTypeDefinition().IsAssignableFrom(typeof(Repository<,,>)))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder;
        }

      
    }
}