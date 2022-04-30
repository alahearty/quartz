namespace Quartz.Domain.Reservoirs
{
    public class AquiferParameters
    {
        public virtual string AquiferModel { get; set; }
        public virtual double OuterInnerRadiusRatio { get; set; }
        public virtual double ReservoirRadius { get; set; }
        public virtual double Encroachmentangle { get; set; }
        public virtual double AquiferPermeability { get; set; }
    }
}
