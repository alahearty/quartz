using quartz.application.reservoirs;
using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;
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
using System.Windows.Shapes;

namespace quartz.wpf
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell 
    {
        private readonly APIClient aPIClient;

        public Shell(APIClient aPIClient, ShellViewModel shellViewModel)
        {
            InitializeComponent();
            this.aPIClient = aPIClient;
            this.DataContext = shellViewModel;
            shellViewModel.CloseWindowRequest += () => this.Close();

            #region APIClient Test
            //this.aPIClient = aPIClient;
            //var clist = aPIClient.Get<List<TodoReponse>>(APIQuery.Create("https://jsonplaceholder.typicode.com/todos/")); 
            #endregion
        }
    }
}
