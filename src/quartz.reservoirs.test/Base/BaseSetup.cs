

using Microsoft.Practices.Unity;
using quartz.reservoirs.test.mocking;
using quartz.wpf.common.Interfaces;

namespace quartz.reservoirs.test.Base
{
    public class BaseSetup
    {
        public BaseSetup()
        {
            Container = new UnityContainer();
            Container.RegisterType<ITabDockService, TabbedWindowExtensionTest>();
            Container.RegisterType<IAuthenticationService, AuthenticationServiceTest>();
            Container.RegisterType<IAPIClient, APIClientTest>();
        }

        protected IUnityContainer Container { get; }
    }
}
