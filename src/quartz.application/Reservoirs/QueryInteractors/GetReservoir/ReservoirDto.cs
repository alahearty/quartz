using Quartz.Domain.Reservoirs;
using System;

namespace Quartz.Application.Reservoirs.QueryInteractors
{
    public class ReservoirDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResevoirFluidType { get; set; }
        public double InitialReservoirPressure { get; set; }
        public double Temperature { get; set; }
        public double OriginalGasCapRatio { get; set; }
        public double PressureDatumDepth { get; set; }
        public double STOIIP { get; set; }
        public double UtimateRecovery { get; set; }

        public AquiferParametersDto AquiferParameter { get; set; }
        public BHPDto BHP { get; set; }
        public ImpuritiesDto Impurities { get; set; }
        public RockDto Rock { get; set; }
        public PVTDto PVT { get; set; }


        public class AquiferParametersDto
        {
            public string AquiferModel { get; set; }
            public double OuterInnerRadiusRatio { get; set; }
            public double ReservoirRadius { get; set; }
            public double Encroachmentangle { get; set; }
            public double AquiferPermeability { get; set; }

            public static implicit operator AquiferParametersDto(AquiferParameters v)
            {
                return new AquiferParametersDto
                {
                    AquiferModel = v.AquiferModel,
                    OuterInnerRadiusRatio = v.OuterInnerRadiusRatio,
                    ReservoirRadius = v.ReservoirRadius,
                    Encroachmentangle = v.Encroachmentangle,
                    AquiferPermeability = v.AquiferPermeability
                };
            }
        }

        public class BHPDto
        {
            public DateTime Date { get; set; }
            public double Pressure { get; set; }
            public string DrainagePoint { get; set; }

            public static implicit operator BHPDto(BHP v)
            {
                return new BHPDto
                {
                    Date = v.Date,
                    Pressure = v.Pressure,
                    DrainagePoint = v.DrainagePoint
                };
            }
        }

        public class ImpuritiesDto
        {
            public double CO2 { get; set; }
            public double H2S { get; set; }
            public double N2 { get; set; }

            public static implicit operator ImpuritiesDto(Impurities v)
            {
                return new ImpuritiesDto
                {
                    CO2 = v.CO2,
                    H2S = v.H2S,
                    N2 = v.N2
                };
            }
        }

        public class PVTDto
        {
            public string ModelType { get; set; }
            public string RsandBo { get; set; }
            public string Viscosity { get; set; }

            public static implicit operator PVTDto(PVT v)
            {
                return new PVTDto
                {
                    ModelType = v.ModelType,
                    RsandBo = v.RsandBo,
                    Viscosity = v.Viscosity
                };
            }
        }

        public class RockDto
        {
            public ResidualFluidSaturationDto ResidualFluidSaturation { get; set; }
            public RockPorosityDto RockPorosity { get; set; }

            public static implicit operator RockDto(Rock v)
            {
                return new RockDto
                {
                    ResidualFluidSaturation = new ResidualFluidSaturationDto
                    {
                        Gas = v.ResidualFluidSaturation.Gas,
                        Oil = v.ResidualFluidSaturation.Oil,
                        Water = v.ResidualFluidSaturation.Water
                    },
                    RockPorosity = new RockPorosityDto
                    {
                        ReservoirPermeability = v.RockPorosity.ReservoirPermeability,
                        ReservoirPorosity = v.RockPorosity.ReservoirPorosity
                    }
                };
            }

            public class ResidualFluidSaturationDto
            {
                public double Gas { get; set; }
                public double Oil { get; set; }
                public double Water { get; set; }
            }

            public class RockPorosityDto
            {
                public double ReservoirPermeability { get; set; }
                public double ReservoirPorosity { get; set; }
            }
        }

        public static ReservoirDto From(Reservoir reservoir)
        {
            if (reservoir == null) return null;

            return new ReservoirDto
            {
                Id = reservoir.Id,
                Name = reservoir.Name,
                UtimateRecovery = reservoir.UtimateRecovery,
                Temperature = reservoir.Temperature,
                STOIIP = reservoir.STOIIP,
                PressureDatumDepth = reservoir.PressureDatumDepth,
                InitialReservoirPressure = reservoir.InitialReservoirPressure,
                OriginalGasCapRatio = reservoir.OriginalGasCapRatio,
                ResevoirFluidType = reservoir.ResevoirFluidType,
                AquiferParameter = new AquiferParameters
                {
                    AquiferModel = reservoir.AquiferParameter.AquiferModel,
                    AquiferPermeability = reservoir.AquiferParameter.AquiferPermeability,
                    Encroachmentangle = reservoir.AquiferParameter.Encroachmentangle,
                    OuterInnerRadiusRatio = reservoir.AquiferParameter.OuterInnerRadiusRatio,
                    ReservoirRadius = reservoir.AquiferParameter.ReservoirRadius
                },
                BHP = new BHP
                {
                    Date = DateTime.Now,
                    DrainagePoint = reservoir.BHP.DrainagePoint,
                    Pressure = reservoir.BHP.Pressure
                },
                Impurities = new Impurities
                {
                    CO2 = reservoir.Impurities.CO2,
                    H2S = reservoir.Impurities.H2S,
                    N2 = reservoir.Impurities.N2
                },
                PVT = new PVT
                {
                    ModelType = reservoir.PVT.ModelType,
                    RsandBo = reservoir.PVT.RsandBo,
                    Viscosity = reservoir.PVT.Viscosity
                },
                Rock = new Rock
                {
                    ResidualFluidSaturation = new ResidualFluidSaturation
                    {
                        Gas = reservoir.Rock.ResidualFluidSaturation.Gas,
                        Oil = reservoir.Rock.ResidualFluidSaturation.Oil,
                        Water = reservoir.Rock.ResidualFluidSaturation.Water
                    },
                    RockPorosity = new RockPorosity
                    {
                        ReservoirPermeability = reservoir.Rock.RockPorosity.ReservoirPermeability,
                        ReservoirPorosity = reservoir.Rock.RockPorosity.ReservoirPorosity
                    }
                }
            };
        }
    }
}