using quartz.application.reservoirs.ViewModels;
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

namespace quartz.application.reservoirs.Views.ToolWindow
{
    /// <summary>
    /// Interaction logic for ToolWindow.xaml
    /// </summary>
    public partial class AssetExplorer : UserControl
    {
        public const string ViewName = "AssetExplorerWindow"; 
        public AssetExplorer(AssetExplorerViewModel assetExplorerViewModel)
        {
            InitializeComponent();
            DataContext = assetExplorerViewModel;
            this.Loaded += (s, e) => assetExplorerViewModel.GetReservoirsAsync();
        }

    }
}
