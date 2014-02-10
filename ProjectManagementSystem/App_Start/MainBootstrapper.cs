using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Bootstrap;
using Unity.Mvc4;

namespace ProjectManagementSystem
{
    public static class MainBootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            new SystemBootstrapper(container).BuildDependency();
            return container;
        }

    }
}