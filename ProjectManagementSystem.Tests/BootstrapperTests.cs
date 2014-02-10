using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementSystem.Bll;
using ProjectManagementSystem.BllInterfaces;
using ProjectManagementSystem.BllRequirements;
using ProjectManagementSystem.Bootstrap;
using ProjectManagementSystem.Dal;
using ProjectManagementSystem.Logger;
using ProjectManagementSystem.LoggerInterfaces;
using ProjectManagementSystem.UiHelper;

namespace ProjectManagementSystem.Tests
{
    [TestClass]
    public class BootstrapperTests
    {
        [TestMethod]
        public void ContainerTest()
        {
            var container = new UnityContainer();
            var bootstrapper = new SystemBootstrapper(container);
            bootstrapper.BuildDependency();

            Assert.IsNotNull(container.Resolve<IManager>());
            Assert.IsInstanceOfType(container.Resolve<IManager>(), typeof(Manager));
            Assert.IsInstanceOfType(container.Resolve<IStorage>(), typeof(DatabaseStorage));
            Assert.IsInstanceOfType(container.Resolve<ICurrentUserProvider>(), typeof(CurrentUserProvider));
            Assert.IsInstanceOfType(container.Resolve<ILogger>(), typeof(EmptyLogger));
            Assert.IsInstanceOfType(container.Resolve<IDateProvider>(), typeof(DateProvider));
        }
    }
}
