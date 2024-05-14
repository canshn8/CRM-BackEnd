using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            ////Manager - Service
            builder.RegisterType<AuthManager>().As<IAuthService>();


            builder.RegisterType<StudentManager>().As<IStudentService>();

            builder.RegisterType<StudentContactManager>().As<IStudentContactService>();

            builder.RegisterType<StudentStartingManager>().As<IStudentStartingService>();


            builder.RegisterType<UserManager>().As<IUserService>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                       .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                       {
                           Selector = new AspectInterceptorSelector()
                       }).SingleInstance();

        }
    }
}