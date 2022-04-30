using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Interfaces
{
    public interface ITabDockService
    {
        void DockTab(object view, string title);
        void DockView(string region, object view);
    } 
}
