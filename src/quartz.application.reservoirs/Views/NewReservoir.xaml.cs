using quartz.application.reservoirs.ViewModels;
using System.Windows;
using System.Windows.Navigation;

namespace quartz.application.reservoirs.Views
{
    /// <summary>
    /// Interaction logic for NewReservoir.xaml
    /// </summary>
    public partial class NewReservoir : Window
    {
        public NewReservoir(NewReservoirViewModel newReservoirViewModel)
        {
            InitializeComponent();
            DataContext = newReservoirViewModel;
            newReservoirViewModel.CloseAction += (s, e) => this.Close();
        }

        private void Frame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateFrameDataContext(sender, e);
        }

        private void UpdateFrameDataContext(object sender, NavigationEventArgs e)
        {
            var content = frame.Content as FrameworkElement;
            if (content == null)
                return;
            content.DataContext = (frame.DataContext as NewReservoirViewModel).Reservoir;
        }
    }
}
