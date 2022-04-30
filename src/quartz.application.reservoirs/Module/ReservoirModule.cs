using ActiproSoftware.Windows.Controls.Docking;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
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
        private readonly IUnityContainer unityContainer;
        private IRegionManager _regionManager;
        public ReservoirModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            this.unityContainer = unityContainer;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.Regions[ApplicationRegions.TOOL_WINDOW_CONTAINER]
                .Add(new ToolWindow() {
                    Title = "Reservoirs",
                    Content = unityContainer.Resolve<AssetExplorer>()
                }, AssetExplorer.ViewName);

            _regionManager.RegisterViewWithRegion(ApplicationRegions.HOME_RIBBON_TAB_REGION, typeof(ReservoirRibbon));
        }
    }
}
