#if ACTIPRO
using ActiproSoftware.Windows.Controls.Docking;
#endif
using Prism.Commands;
using Prism.Regions;
using quartz.application.reservoirs.Views.ToolWindow;
using quartz.wpf.common;
using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;
using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace quartz.application.reservoirs.ViewModels
{
    public class NewReservoirViewModel
    {
        private readonly IAPIClient aPIClient;
        private readonly AssetExplorerViewModel assetExplorerViewModel;

        public event EventHandler CloseAction;

        public Reservoir Reservoir { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public NewReservoirViewModel(IAPIClient aPIClient, IRegionManager regionManager, AssetExplorerViewModel assetExplorerViewModel)
        {
            Reservoir = new Reservoir { AquiferParameter=new AquiferParameters(), Impurities=new Impurities(), PVT=new PVT(),
                Rock =new Rock {ResidualFluidSaturation=new ResidualFluidSaturation() ,RockPorosity=new RockPorosity()},
                BHP = new BHP()
            };
            SaveCommand = new DelegateCommand(Save);
            this.aPIClient = aPIClient;
            this.assetExplorerViewModel = assetExplorerViewModel;
        }

        private async void Save()
        {
            CloseAction.Invoke(this, EventArgs.Empty);

            var response = await Task.Run(() =>
            {
                return aPIClient.Post(APIQuery.Create(UrlConstants.ReservoirList), new CreateReservoirRequest(this.Reservoir));
            });
            if (response.Status == "OK")
            {
                assetExplorerViewModel.AddNewReservoir(response.Data, this.Reservoir);
                MessageBox.Show("Saved...", "Demo Project", MessageBoxButton.OK);
            }
            else
                MessageBox.Show(response.Message, "SEPAL", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
