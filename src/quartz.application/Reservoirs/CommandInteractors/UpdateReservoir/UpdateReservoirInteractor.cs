using MediatR;
using Quartz.Application.Reservoirs.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Application.Reservoirs.CommandInteractors
{
    public class UpdateReservoirInteractor : IRequestHandler<UpdateReservoirRequest, int>
    {
        private readonly IReservoirRepository _reservoirRepository;

        public UpdateReservoirInteractor(IReservoirRepository reservoirRepository)
        {
            _reservoirRepository = reservoirRepository;
        }

        public Task<int> Handle(UpdateReservoirRequest request, CancellationToken cancellationToken)
        {
            var reservoir = _reservoirRepository.GetById(request.Id);
            if (reservoir == null)
            {
                throw new InvalidQuartzOperationException($"Reservoir with id: '{request.Id}' does not exist!");
            }

            reservoir.Id = request.Id;
            reservoir.Name = request.Name;
            reservoir.UtimateRecovery = request.UtimateRecovery;
            reservoir.Temperature = request.Temperature;
            reservoir.STOIIP = request.STOIIP;
            reservoir.PressureDatumDepth = request.PressureDatumDepth;
            reservoir.InitialReservoirPressure = request.InitialReservoirPressure;
            reservoir.OriginalGasCapRatio = request.OriginalGasCapRatio;
            reservoir.ResevoirFluidType = request.ResevoirFluidType;
            reservoir.AquiferParameter.AquiferModel = request.AquiferParameter.AquiferModel;
            reservoir.AquiferParameter.AquiferPermeability = request.AquiferParameter.AquiferPermeability;
            reservoir.AquiferParameter.Encroachmentangle = request.AquiferParameter.Encroachmentangle;
            reservoir.AquiferParameter.OuterInnerRadiusRatio = request.AquiferParameter.OuterInnerRadiusRatio;
            reservoir.AquiferParameter.ReservoirRadius = request.AquiferParameter.ReservoirRadius;
            reservoir.BHP.Date = DateTime.Now;
            reservoir.BHP.DrainagePoint = request.BHP.DrainagePoint;
            reservoir.BHP.Pressure = request.BHP.Pressure;
            reservoir.Impurities.CO2 = request.Impurities.CO2;
            reservoir.Impurities.H2S = request.Impurities.H2S;
            reservoir.Impurities.N2 = request.Impurities.N2;
            reservoir.PVT.ModelType = request.PVT.ModelType;
            reservoir.PVT.RsandBo = request.PVT.RsandBo;
            reservoir.PVT.Viscosity = request.PVT.Viscosity;
            reservoir.Rock.ResidualFluidSaturation.Gas = request.Rock.ResidualFluidSaturation.Gas;
            reservoir.Rock.ResidualFluidSaturation.Oil = request.Rock.ResidualFluidSaturation.Oil;
            reservoir.Rock.ResidualFluidSaturation.Water = request.Rock.ResidualFluidSaturation.Water;
            reservoir.Rock.RockPorosity.ReservoirPermeability = request.Rock.RockPorosity.ReservoirPermeability;
            reservoir.Rock.RockPorosity.ReservoirPorosity = request.Rock.RockPorosity.ReservoirPorosity;

            try
            {
                _reservoirRepository.Update(reservoir);
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
