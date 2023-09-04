using Autofac;
using repositorypattern.Repository;

namespace repositorypattern
{
    public sealed class AutofacModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {





            // Transient         
            builder.RegisterType<InMemoryProductRepository>().As<IProductRepository>()
                .SingleInstance();
            builder.RegisterType<CustomMiddleware>()
                .InstancePerDependency();


            //// Scoped
            //builder.RegisterType<Methods>().As<IMethods>()
            //        .InstancePerLifetimeScope();



            //// Singleton

            //builder.RegisterType<Methods>().As<IMethods>()
            //    .SingleInstance();





        }
    }
}
