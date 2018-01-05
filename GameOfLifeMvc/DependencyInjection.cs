using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using GameOfLifeMvc.Engine;
using GameOfLifeMvc.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GameOfLifeMvc
{
    public static class DependencyInjection
    {
        public static void ConfigureContainer()
        {

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            Register(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<GameOfLifeMvcEngine>().As<IGameOfLifeMvcEngine>().SingleInstance();
            builder.RegisterType<GameEngine>().As<IGameEngine>().SingleInstance();
        }
    }
}