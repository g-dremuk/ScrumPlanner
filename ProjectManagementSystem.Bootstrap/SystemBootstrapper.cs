using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using ProjectManagementSystem.Bll;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Dal;
using ProjectManagementSystem.Debugging;
using ProjectManagementSystem.UiHelper;

namespace ProjectManagementSystem.Bootstrap
{
    public class SystemBootstrapper
    {
        private readonly IUnityContainer _container;

        public SystemBootstrapper(IUnityContainer container)
        {
            _container = container;
        }

        public void BuildDependency()
        {
            #region UI bootstrap

            _container.RegisterType<ICurrentUserProvider, CurrentUserProvider>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IDateProvider, DateProvider>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUsersProvider, UsersProvider>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IRoleProvider, RoleProvider>(new ContainerControlledLifetimeManager());
            
            #endregion

            #region Bll bootstrap

            _container.RegisterType<IManager, Manager>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IAdmin, Admin>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IItemsLists, ItemsLists>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IProgrammer, Programmer>(new ContainerControlledLifetimeManager());

            #endregion

            #region Storage bootstrap

            _container.RegisterType<IStorage, DatabaseStorage>(new ContainerControlledLifetimeManager());

            #endregion
        }
    }
}
