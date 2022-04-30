namespace quartz.wpf.domain.Models.Reservoirs
{
    public class RockPorosity : ModelBase
    {
        private double _reservoirPermeability;
        private double _reservoirPorosity;

        public double ReservoirPermeability { get => _reservoirPermeability; set { _reservoirPermeability = value; OnPropertyChanged("ReservoirPermeability"); } }
        public double ReservoirPorosity { get => _reservoirPorosity; set { _reservoirPorosity = value; OnPropertyChanged("ReservoirPorosity"); } }
    }
}