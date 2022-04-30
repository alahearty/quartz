using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Unity;
using quartz.application.reservoirs.Views;
using quartz.wpf.common.Client;
using quartz.wpf.common.CompositionEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.application.reservoirs.ViewModels
{
    public class RibbonBarViewModel
    {
        private readonly IUnityContainer _unityContainer;
        public DelegateCommand CreateReservoirCommand { get; private set; }

        public RibbonBarViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            CreateReservoirCommand = new DelegateCommand(CreateNewReservoirAction);
        }

        private void CreateNewReservoirAction()
        {
            var newReservoirWindow = _unityContainer.Resolve<NewReservoir>();
            newReservoirWindow.Show();
        }
    }
}
