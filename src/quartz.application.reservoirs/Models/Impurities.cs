namespace quartz.wpf.domain.Models.Reservoirs
{
    public class Impurities : ModelBase
    {
        private double _cO2;
        private double _h2S;
        private double _n2;

        public double CO2 { get => _cO2; set { _cO2 = value; OnPropertyChanged("CO2"); } }
        public double H2S { get => _h2S; set { _h2S = value; OnPropertyChanged("H2S"); } }
        public double N2 { get => _n2; set { _n2 = value; OnPropertyChanged("N2"); } }
    }
}