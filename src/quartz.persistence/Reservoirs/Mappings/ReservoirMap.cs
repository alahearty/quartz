using FluentNHibernate.Mapping;
using Quartz.Domain.Reservoirs;

namespace Quartz.Persistence.Nhibernate.Mappings
{
    public class ReservoirMap: ClassMap<Reservoir>
    {
        public ReservoirMap()
        {
            Table("Reservoirs");
            Id(x => x.Id);

            //References(x => x.User);

            Map(x => x.Name).Unique();
            Map(x => x.ResevoirFluidType);
            Map(x => x.InitialReservoirPressure);
            Map(x => x.Temperature);
            Map(x => x.OriginalGasCapRatio);
            Map(x => x.PressureDatumDepth);
            Map(x => x.STOIIP);
            Map(x => x.UtimateRecovery);

            Component(x => x.AquiferParameter, m =>
            {
                m.Map(x => x.AquiferModel);
                m.Map(x => x.AquiferPermeability);
                m.Map(x => x.Encroachmentangle);
                m.Map(x => x.OuterInnerRadiusRatio);
                m.Map(x => x.ReservoirRadius);
            });

            Component(x => x.BHP, m =>
            {
                m.Map(x => x.Date);
                m.Map(x => x.DrainagePoint);
                m.Map(x => x.Pressure);
            });

            Component(x => x.Impurities, m =>
            {
                m.Map(x => x.CO2);
                m.Map(x => x.H2S);
                m.Map(x => x.N2);
            });

            Component(x => x.Rock, m =>
            {
                m.Component(y => y.ResidualFluidSaturation, y =>
                {
                    y.Map(s => s.Gas);
                    y.Map(s => s.Oil);
                    y.Map(s => s.Water);
                });
                m.Component(y => y.RockPorosity, y =>
                {
                    y.Map(s => s.ReservoirPermeability);
                    y.Map(s => s.ReservoirPorosity);
                });
            });

            Component(x => x.PVT, m =>
            {
                m.Map(x => x.ModelType);
                m.Map(x => x.RsandBo);
                m.Map(x => x.Viscosity);
            });
        }
    }
}
