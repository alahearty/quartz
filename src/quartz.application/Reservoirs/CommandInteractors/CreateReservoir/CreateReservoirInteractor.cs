using MediatR;
using Quartz.Application.Reservoirs.Interfaces;
using Quartz.Domain.Reservoirs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Application.Reservoirs.CommandInteractors
{
    public class CreateReservoirInteractor : IRequestHandler<CreateReservoirRequest, int>
    {
        private readonly IReservoirRepository _reservoirRepository;

        public CreateReservoirInteractor(IReservoirRepository reservoirRepository)
        {
            _reservoirRepository = reservoirRepository;
        }

        public Task<int> Handle(CreateReservoirRequest request, CancellationToken cancellationToken)
        {
            var reservoir = new Reservoir
            {
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

            try
            {
                _reservoirRepository.Save(reservoir);
                _reservoirRepository.Transaction.Commit();
            }
            catch (Exception)
            {
                return Task.FromResult(0);
            }

            return Task.FromResult(reservoir.Id);
        }
    }
}
