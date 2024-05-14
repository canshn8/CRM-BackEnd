﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB;

namespace DataAccess.DependencyResolvers
{
    public class AutoFacDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDB_UserDal>().As<IUserDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                       .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                       {
                           Selector = new AspectInterceptorSelector()
                       }).SingleInstance();

        }
    }
}