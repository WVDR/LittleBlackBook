using IreneAdler.DataAccessRepository;
using IreneAdler.Services;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using Unity.WebApi;
using IreneAdler.Models;

namespace IreneAdler
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataAccessRepository<CONTACT, long>, ClsDataAccessRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}