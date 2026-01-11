using System.Windows;
using Prism.Unity;
using Unity;
using System.Windows.Controls.Ribbon;
using Prism.Regions;
using Prism.Ioc;
using quartz.wpf.RegionAdapters;
using Prism.Modularity;
#if ACTIPRO
using ActiproSoftware.Windows.Controls.Docking;
using ActiproSoftware.Windows.Prism.Regions;
#endif
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

            var containerProvider = Container.Resolve<IContainerProvider>();
            var ribbonTabRegionAdapter = containerProvider.Resolve<RibbonTabRegionAdapter>();
            var mdiHostRegionAdapter = containerProvider.Resolve<MDIHostRegionAdapter>();
            var toolWindowContainerRegionAdapter = containerProvider.Resolve<ToolWindowContainerRegionAdapter>();
#if ACTIPRO
            var actiproDockSiteRegionAdapter = containerProvider.Resolve<DockSiteRegionAdapter>();
            mappings.RegisterMapping(typeof(DockSite), actiproDockSiteRegionAdapter);
            mappings.RegisterMapping(typeof(TabbedMdiContainer), mdiHostRegionAdapter);
#endif

            mappings.RegisterMapping(typeof(RibbonTab), ribbonTabRegionAdapter);
            mappings.RegisterMapping(typeof(ToolWindowContainer), toolWindowContainerRegionAdapter);

            return mappings;
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>() as Window;
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
            containerRegistry.Register<Shell>();
            containerRegistry.Register<ITabDockService, TabbedWindowExtension>();
            containerRegistry.Register<IAPIClient, APIClient>();
            containerRegistry.Register<RibbonTabRegionAdapter>();
            containerRegistry.Register<MDIHostRegionAdapter>();
            containerRegistry.Register<ToolWindowContainerRegionAdapter>();
#if ACTIPRO
            containerRegistry.Register<DockSiteRegionAdapter>();
#endif
        }
    }
}
