namespace Quartz.Domain.Reservoirs
{
    public class Rock
    {
        public virtual ResidualFluidSaturation ResidualFluidSaturation { get; set; } = new ResidualFluidSaturation();
        public virtual RockPorosity RockPorosity { get; set; } = new RockPorosity();
    }
}
