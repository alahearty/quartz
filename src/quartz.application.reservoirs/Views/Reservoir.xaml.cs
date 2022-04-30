using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace quartz.application.reservoirs.Views
{
    /// <summary>
    /// Interaction logic for Reservoir.xaml
    /// </summary>
    public partial class ReservoirFrame : UserControl
    {
        public ReservoirFrame(Reservoir reservoir)
        {
            InitializeComponent();
            DataContext = reservoir;
        }

        private void frame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext(sender, e);
        }

        private void UpdateFrameDataContext(object sender, NavigationEventArgs e)
        {
            var content = frame.Content as FrameworkElement;
            if (content == null)
                return;
            content.DataContext = frame.DataContext;
        }
    }
}
