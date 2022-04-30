using Quartz.Domain.Users;

namespace Quartz.Domain.Reservoirs
{
    public class Reservoir : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string ResevoirFluidType { get; set; }
        public virtual double InitialReservoirPressure { get; set; }
        public virtual double Temperature { get; set; }
        public virtual double OriginalGasCapRatio { get; set; }
        public virtual double PressureDatumDepth { get; set; }
        public virtual double STOIIP { get; set; }
        public virtual double UtimateRecovery { get; set; }

        public virtual AquiferParameters AquiferParameter { get; set; } = new AquiferParameters();
        public virtual BHP BHP { get; set; } = new BHP();
        public virtual Impurities Impurities { get; set; } = new Impurities();
        public virtual Rock Rock { get; set; } = new Rock();
        public virtual PVT PVT { get; set; } = new PVT();

        //public User User { get; set; }
    }
}
