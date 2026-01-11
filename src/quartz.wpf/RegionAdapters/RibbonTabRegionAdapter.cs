using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Ribbon;

namespace quartz.wpf.RegionAdapters
{
    public class RibbonTabRegionAdapter : RegionAdapterBase<Ribbon>
    {
        public RibbonTabRegionAdapter(IRegionBehaviorFactory factory) : base(factory) { }

        protected override void Adapt(IRegion region, Ribbon regionTarget)
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
                    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                    {

                        foreach (FrameworkElement element in e.NewItems)
                        {
                            regionTarget.Items.Remove(element);
                        }
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

    }
}
