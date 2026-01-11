using ActiproSoftware.Windows.Controls.Docking;
using Prism.Regions;
using quartz.wpf.common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common
{
    public class TabbedWindowExtension: ITabDockService
    {
        private readonly IRegionManager regionManager;

        public TabbedWindowExtension(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void DockTab(object view, string title)
        {
            var view_ = regionManager.Regions[ApplicationRegions.DOCK_SITE_REGION].GetView(title);
            if (view_ != null)
            {
                (view_ as DockingWindow).Activate();
                return;
            }
            var doc_wnd = new DocumentWindow() { Title = title, Content = view };
            doc_wnd.Unloaded += Doc_wnd_Unloaded;
            regionManager.Regions[ApplicationRegions.DOCK_SITE_REGION].Add(doc_wnd, title);
            doc_wnd.Activate();
        }

        private void Doc_wnd_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
           try
            {
                var region = regionManager.Regions[ApplicationRegions.DOCK_SITE_REGION];
                if (region != null)
                    region.Remove(sender);
            }catch (Exception ex)
            {
                return;
            }
        }

        public void DockView(string region, object view)
        {
            if (view is DocumentWindow)
            {
                var doc = (view as DocumentWindow);
                doc.Unloaded += DockView_Unloaded;
                doc.Tag = region;
            }
            regionManager.AddToRegion(region, view);
        }

        private void DockView_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var docking_wnd = (sender as DockingWindow);
            if (docking_wnd.Tag != null)
            {
                var region = regionManager.Regions[docking_wnd.Tag.ToString()];
                if (region != null)
                    region.Remove(sender);
            }
        }
    }
}
