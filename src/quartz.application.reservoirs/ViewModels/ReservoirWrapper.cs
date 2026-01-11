using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;
using quartz.application.reservoirs.ViewModels;
using quartz.application.reservoirs.Views;
using quartz.wpf.common.Interfaces;
using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace quartz.application.reservoirs
{
    public class ReservoirWrapper: BindableBase
    {
        private readonly ITabDockService tabService;

        public DelegateCommand Command { get; set; }

        private readonly ReservoirIndexResponse _reservoirIndex;
        private readonly AssetExplorerViewModel assetExplorerViewModel;
        private Reservoir _reservoir;

        public ReservoirIndexResponse ReservoirIndex
        {
            get { return _reservoirIndex; }
        }

        public Reservoir Reservoir
        {
            get { return _reservoir; }
        }

        public ReservoirWrapper(ITabDockService tabDockService, ReservoirIndexResponse reservoirIndex, AssetExplorerViewModel assetExplorerViewModel)
        {
            tabService = tabDockService;
            Command = new DelegateCommand(InjectReservoir);
            this._reservoirIndex = reservoirIndex;
            this.assetExplorerViewModel = assetExplorerViewModel;
        }

        public ReservoirWrapper(ITabDockService tabDockService, ReservoirIndexResponse reservoirIndex, 
            AssetExplorerViewModel assetExplorerViewModel, Reservoir reservoir):this(tabDockService, reservoirIndex, assetExplorerViewModel)
        {
            _reservoir = reservoir;
        }

        private void InjectReservoir()
        {
            if (_reservoir == null)
                _reservoir = assetExplorerViewModel.GetReservoir(this._reservoirIndex.ReservoirId);
            // TODO: fetch reservoir data from db using the name or id or whatever is available.

            //inject the data as datacontext to populate the view
            tabService.DockTab(new ReservoirFrame(_reservoir), this.ReservoirIndex.ReservoirName);
        }
    }
}
