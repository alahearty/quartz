using MediatR;
using Quartz.Domain.Reservoirs;
using System;

namespace Quartz.Application.Reservoirs.CommandInteractors
{
    public class CreateReservoirRequest : IRequest<int>
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

        public AquiferParametersDto AquiferParameter { get; set; } = new AquiferParametersDto();
        public BHPDto BHP { get; set; } = new BHPDto();
        public ImpuritiesDto Impurities { get; set; } = new ImpuritiesDto();
        public RockDto Rock { get; set; } = new RockDto();
        public PVTDto PVT { get; set; } = new PVTDto();


        public class AquiferParametersDto
        {
            public string AquiferModel { get; set; }
            public double OuterInnerRadiusRatio { get; set; }
            public double ReservoirRadius { get; set; }
            public double Encroachmentangle { get; set; }
            public double AquiferPermeability { get; set; }
        }

        public class BHPDto
        {
            public DateTime Date { get; set; }
            public double Pressure { get; set; }
            public string DrainagePoint { get; set; }
        }

        public class ImpuritiesDto
        {
            public double CO2 { get; set; }
            public double H2S { get; set; }
            public double N2 { get; set; }
        }

        public class PVTDto
        {
            public string ModelType { get; set; }
            public string RsandBo { get; set; }
            public string Viscosity { get; set; }
        }

        public class RockDto
        {
            public ResidualFluidSaturationDto ResidualFluidSaturation { get; set; } = new ResidualFluidSaturationDto();
            public RockPorosityDto RockPorosity { get; set; } = new RockPorosityDto();
            
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

        public static Reservoir Reservoir(CreateReservoirRequest request)
        {
            return new Reservoir
            {
                Id = request.Id,
                Name = request.Name,
                UtimateRecovery = request.UtimateRecovery,
                Temperature = request.Temperature,
                STOIIP = request.STOIIP,
                PressureDatumDepth = request.PressureDatumDepth,
                InitialReservoirPressure = request.InitialReservoirPressure,
                OriginalGasCapRatio = request.OriginalGasCapRatio,
                ResevoirFluidType = request.ResevoirFluidType,
                AquiferParameter = new AquiferParameters
                {
                    AquiferModel = request.AquiferParameter.AquiferModel,
                    AquiferPermeability = request.AquiferParameter.AquiferPermeability,
                    Encroachmentangle = request.AquiferParameter.Encroachmentangle,
                    OuterInnerRadiusRatio = request.AquiferParameter.OuterInnerRadiusRatio,
                    ReservoirRadius = request.AquiferParameter.ReservoirRadius
                },
                BHP = new BHP
                {
                    Date = DateTime.Now,
                    DrainagePoint = request.BHP.DrainagePoint,
                    Pressure = request.BHP.Pressure
                },
                Impurities = new Impurities
                {
                    CO2 = request.Impurities.CO2,
                    H2S = request.Impurities.H2S,
                    N2 = request.Impurities.N2
                },
                PVT = new PVT
                {
                    ModelType = request.PVT.ModelType,
                    RsandBo = request.PVT.RsandBo,
                    Viscosity = request.PVT.Viscosity
                },
                Rock = new Rock
                {
                    ResidualFluidSaturation = new ResidualFluidSaturation
                    {
                        Gas = request.Rock.ResidualFluidSaturation.Gas,
                        Oil = request.Rock.ResidualFluidSaturation.Oil,
                        Water = request.Rock.ResidualFluidSaturation.Water
                    },
                    RockPorosity = new RockPorosity
                    {
                        ReservoirPermeability = request.Rock.RockPorosity.ReservoirPermeability,
                        ReservoirPorosity = request.Rock.RockPorosity.ReservoirPorosity
                    }
                }
            };
        }
    }
}
