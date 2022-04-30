using quartz.wpf.common.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.domain.Models.Reservoirs
{
    public class Reservoir : ModelBase
    {
        private string _name;
        private string _resevoirFluidType;
        private double _initialReservoirPressure;
        private double _temperature;
        private double _originalGasCapRatio;
        private double _pressureDatumDepth;
        private double _sTOIIP;
        private double _utimateRecovery;
        private AquiferParameters _aquiferParameter;
        private BHP _bHP;
        private Impurities _impurities;
        private Rock _rock;
        private PVT _pVT;
        private User _user;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string ResevoirFluidType
        {
            get => _resevoirFluidType; set { _resevoirFluidType = value; OnPropertyChanged("ResevoirFluidType"); }
        }
        public double InitialReservoirPressure
        {
            get => _initialReservoirPressure;
            set { _initialReservoirPressure = value; OnPropertyChanged("InitialReservoirPressure"); }
        }
        public double Temperature { get => _temperature; set { _temperature = value; OnPropertyChanged("Temperature"); } }
        public double OriginalGasCapRatio { get => _originalGasCapRatio; set { _originalGasCapRatio = value; OnPropertyChanged("OriginalGasCapRatio"); } }
        public double PressureDatumDepth { get => _pressureDatumDepth; set { _pressureDatumDepth = value; OnPropertyChanged("PressureDatumDepth"); } }
        public double STOIIP { get => _sTOIIP; set { _sTOIIP = value; OnPropertyChanged("STOIIP"); } }
        public double UtimateRecovery { get => _utimateRecovery; set { _utimateRecovery = value; OnPropertyChanged("UtimateRecovery"); } }

        public AquiferParameters AquiferParameter { get => _aquiferParameter; set { _aquiferParameter = value; OnPropertyChanged("AquiferParameter"); } }
        public BHP BHP { get => _bHP; set { _bHP = value; OnPropertyChanged("BHP"); } }
        public Impurities Impurities { get => _impurities; set { _impurities = value; OnPropertyChanged("Impurities"); } }
        public Rock Rock { get => _rock; set { _rock = value; OnPropertyChanged("Rock"); } }
        public PVT PVT { get => _pVT; set { _pVT = value; OnPropertyChanged("PVT"); } }

        public User User { get => _user; set { _user = value; OnPropertyChanged("User"); } }
    }
}
