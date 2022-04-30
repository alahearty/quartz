namespace quartz.wpf.domain.Models.Reservoirs
{
    public class AquiferParameters : ModelBase
    {
        private string _aquiferModel;
        private double _outerInnerRadiusRatio;
        private double _reservoirRadius;
        private double _encroachmentangle;
        private double _aquiferPermeability;

        public string AquiferModel { get => _aquiferModel; set { _aquiferModel = value; OnPropertyChanged("AquiferModel"); } } 
        public double OuterInnerRadiusRatio { get => _outerInnerRadiusRatio; set { _outerInnerRadiusRatio = value; OnPropertyChanged("OuterInnerRadiusRatio"); } }
        public double ReservoirRadius { get => _reservoirRadius; set { _reservoirRadius = value; OnPropertyChanged("ReservoirRadius"); } }
        public double Encroachmentangle { get => _encroachmentangle; set { _encroachmentangle = value; OnPropertyChanged("Encroachmentangle"); } }
        public double AquiferPermeability { get => _aquiferPermeability; set { _aquiferPermeability = value; OnPropertyChanged("AquiferPermeability");  } }
    }
}