namespace quartz.wpf.domain.Models.Reservoirs
{
    public class ResidualFluidSaturation : ModelBase
    {
        private double _gas;
        private double _oil;
        private double _water;

        public double Gas { get => _gas; set { _gas = value; OnPropertyChanged("Gas"); } }
        public double Oil { get => _oil; set { _oil = value; OnPropertyChanged("Oil"); } }
        public double Water { get => _water; set { _water = value; OnPropertyChanged("Water"); } }
    }
}