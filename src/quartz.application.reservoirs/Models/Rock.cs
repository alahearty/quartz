namespace quartz.wpf.domain.Models.Reservoirs
{
    public class Rock : ModelBase
    {
        private ResidualFluidSaturation _residualFluidSaturation;
        private RockPorosity _rockPorosity;

        public ResidualFluidSaturation ResidualFluidSaturation { get => _residualFluidSaturation; set { _residualFluidSaturation = value; OnPropertyChanged("ResidualFluidSaturation"); } }
        public RockPorosity RockPorosity { get => _rockPorosity; set { _rockPorosity = value; OnPropertyChanged("RockPorosity"); } }
    }
}