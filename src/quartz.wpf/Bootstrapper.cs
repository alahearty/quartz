using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Windows.Controls.Ribbon;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using quartz.wpf.RegionAdapters;
using Microsoft.Practices.Prism.Modularity;
using ActiproSoftware.Windows.Controls.Docking;
using ActiproSoftware.Windows.Prism.Regions;
using quartz.wpf.common;
using quartz.wpf.common.Interfaces;
using quartz.application.reservoirs.Module;
using quartz.wpf.Services;
using quartz.wpf.common.Client;

namespace quartz.wpf
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ReservoirModule));
        }


        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();

            var ribbonTabRegionAdapter = ServiceLocator.Current.GetInstance<RibbonTabRegionAdapter>();
            var mdiHostRegionAdapter = ServiceLocator.Current.GetInstance<MDIHostRegionAdapter>();
            var toolWindowContainerRegionAdapter = ServiceLocator.Current.GetInstance<ToolWindowContainerRegionAdapter>();
            var actiproDockSiteRegionAdapter = ServiceLocator.Current.GetInstance<DockSiteRegionAdapter>();

            mappings.RegisterMapping(typeof(RibbonTab), ribbonTabRegionAdapter);
            mappings.RegisterMapping(typeof(TabbedMdiContainer), mdiHostRegionAdapter);
            mappings.RegisterMapping(typeof(DockSite), actiproDockSiteRegionAdapter);
            mappings.RegisterMapping(typeof(ToolWindowContainer), toolWindowContainerRegionAdapter);

            return mappings;
        }

        protected override DependencyObject CreateShell()
        {
            Container.RegisterType<IAuthenticationService, AuthenticationService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<Shell>();
            return this.Container.Resolve<Shell>() as Window;
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void InitializeModules()
        {
            this.Initialize();
            base.InitializeModules();
        }

        private void Initialize()
        {
            Container.RegisterType<ITabDockService, TabbedWindowExtension>();
            Container.RegisterType<IAPIClient, APIClient>();
        }
    }
}
