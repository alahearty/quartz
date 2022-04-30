using quartz.application.reservoirs.ViewModels;
using System.Windows.Controls.Ribbon;

namespace quartz.application.reservoirs.Views
{
    /// <summary>
    /// Interaction logic for ReservoirRibbon.xaml
    /// </summary>
    public partial class ReservoirRibbon
    {
        public ReservoirRibbon(RibbonBarViewModel ribbonViewModel)
        {
            InitializeComponent();
            DataContext = ribbonViewModel;
        }
    }
}
