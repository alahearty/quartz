using ActiproSoftware.Windows.Controls.Docking;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace quartz.wpf.RegionAdapters
{
    public class ToolWindowContainerRegionAdapter : RegionAdapterBase<ToolWindowContainer>
    {
        public ToolWindowContainerRegionAdapter(IRegionBehaviorFactory factory) : base(factory) { }

        protected override void Adapt(IRegion region, ToolWindowContainer regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) => {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {
                        regionTarget.Items.Add(element);
                    }
                }

                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement element in e.OldItems)
                    {
                        regionTarget.Items.Remove(element);
                    }

                }

            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}
