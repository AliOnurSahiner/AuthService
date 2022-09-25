using AuthServiceBussiness.Concrete;
using AuthServicesDAL.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace AuthServiceBussiness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>();
      

            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //Aspectlerin çalışması için gerekli olan configuration (method önünde arkasında vs....)

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
