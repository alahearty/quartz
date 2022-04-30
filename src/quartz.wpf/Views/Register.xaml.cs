using quartz.wpf.ViewModels;
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

namespace quartz.wpf.Views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            this.DataContext = registerViewModel;
            registerViewModel.CloseWndRequest += () => {
                var wnd = (this.Parent as Window);
                wnd.DialogResult = true;
            };
        }
    }
}
