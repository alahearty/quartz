#if ACTIPRO
using ActiproSoftware.Windows.Controls.Docking;
#endif
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;
using quartz.application.reservoirs.ViewModels;
using quartz.application.reservoirs.Views;
using quartz.application.reservoirs.Views.ToolWindow;
using quartz.wpf.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.application.reservoirs.Module
{
    public class ReservoirModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Types are registered via Unity container in bootstrapper
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            var unityContainer = containerProvider.Resolve<IUnityContainer>();

#if ACTIPRO
            regionManager.Regions[ApplicationRegions.TOOL_WINDOW_CONTAINER]
                .Add(new ToolWindow() {
                    Title = "Reservoirs",
                    Content = unityContainer.Resolve<AssetExplorer>()
                }, AssetExplorer.ViewName);
#endif

            regionManager.RegisterViewWithRegion(ApplicationRegions.HOME_RIBBON_TAB_REGION, typeof(ReservoirRibbon));
        }
    }
}
