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
    public class MDIHostRegionAdapter : RegionAdapterBase<TabbedMdiContainer>
    {

        public MDIHostRegionAdapter(IRegionBehaviorFactory factory) : base(factory) { }

        protected override void Adapt(IRegion region, TabbedMdiContainer regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) => {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (object element in e.NewItems)
                    {
                        if (element is FrameworkElement)
                        {
                            regionTarget.Items.Add(element);
                        }
                    }
                }

                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (object element in e.OldItems)
                    {
                        if (element is FrameworkElement)
                        {
                            regionTarget.Items.Remove(element);
                        }
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
