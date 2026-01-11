using Prism.Mvvm;
using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;
using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace quartz.application.reservoirs.ViewModels
{
    public class AssetExplorerViewModel : BindableBase
    {
        private ITabDockService tabDockService;
        private static ObservableCollection<ReservoirWrapper> _reservoirs;
        private IAPIClient api_client;


        public ObservableCollection<ReservoirWrapper> Reservoirs { get => _reservoirs; set { _reservoirs = value; RaisePropertyChanged(() => this.Reservoirs); } }

        public AssetExplorerViewModel(ITabDockService tabDockService, IAPIClient aPIClient)
        {
            this.tabDockService = tabDockService;
            this.api_client = aPIClient;
        }

        public async void GetReservoirsAsync()
        {
            Reservoirs = new ObservableCollection<ReservoirWrapper>();
            var reservoir_response = await Task.Run(() => GetReservoirs());
            if (reservoir_response != null)
            {
                foreach (var item in reservoir_response)
                {
                    Reservoirs.Add(new ReservoirWrapper(tabDockService, item, this));
                }
            }
        }

        public List<ReservoirIndexResponse> GetReservoirs()
        {
            var uri = APIQuery.Create(UrlConstants.ReservoirList);
            var reservoir_response = api_client.Get(uri, new ReservoirListRequest());
            if (reservoir_response.HasData())
                return reservoir_response.Data;
            return null;
        }


        public Reservoir GetReservoir(int id)
        {
            var uri = APIQuery.Create(UrlConstants.ReservoirList).AppendUrl($"{id}");
            var reservoir_response = api_client.Get<Reservoir>(uri);
            //var reservoir_response = await Task.Run(() => { return api_client.Get(uri, ""); });
            if (reservoir_response.HasData())
            {
                return reservoir_response.Data;
            }
            return null;
        }

        public void AddNewReservoir(int data, Reservoir reservoir)
        {
            if (reservoir == null)
                throw new NullReferenceException("Reservoir can not be null");

            Reservoirs.Add(new ReservoirWrapper(tabDockService, 
                new ReservoirIndexResponse {ReservoirId=data, ReservoirName=reservoir.Name }, this, reservoir));
        }
    }
}
