using Autofac;
using Autofac.Extensions.DependencyInjection;
using MailingListApplication.Core;
using MailingListApplication.SharedKernal.Interfaces;
using MailingListApplication.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace MailingListApplication.Infrastructure
{
    public static class ContainerSetup
    {
        public static IServiceProvider InitializeWeb(Assembly webAssembly, IServiceCollection services) =>
            new AutofacServiceProvider(BaseAutofacInitialization(setupAction =>
            {
                setupAction.Populate(services);
                setupAction.RegisterAssemblyTypes(webAssembly).AsImplementedInterfaces();
            }));

        public static IContainer BaseAutofacInitialization(Action<ContainerBuilder> setupAction = null)
        {
            var builder = new ContainerBuilder();

            var infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository));
            var sharedKernelAssembly = Assembly.GetAssembly(typeof(IRepository));
            builder.RegisterAssemblyTypes(sharedKernelAssembly, infrastructureAssembly).AsImplementedInterfaces();

            setupAction?.Invoke(builder);
            return builder.Build();
        }
    }
}
