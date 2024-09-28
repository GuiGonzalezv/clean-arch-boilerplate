using AgrotoolsMaps.Infra.CrossCutting.IoC.Extensions;
using Autofac;

namespace AgrotoolsMaps.Infra.CrossCutting.IoC
{
    public class DependenciesResolveModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterApplicationDependencies()
                .RegisterInfraEntityDependencies();

        }
    }
}