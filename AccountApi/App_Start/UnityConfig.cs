using AccountBAL;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace AccountApi
{
    public static class UnityConfig
    {
        public static Type ILoginBAL { get; private set; }
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ILoginBAL, LoginBAL>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}