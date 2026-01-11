using FluentAssertions;
using MediatR;
using Quartz.Application.Reservoirs.CommandInteractors;
using Quartz.Application.Reservoirs.QueryInteractors;
using Quartz.Core.Domain.Test;
using System;
using System.Collections.Generic;
using Xunit;

namespace Quartz.Core.Domain.ReservoirTest
{
    public class ReservoirInteractorsTest : BaseSetup
    {
        private readonly IMediator _mediator;

        public ReservoirInteractorsTest()
        {
            _mediator = (IMediator)ServiceProvider.GetService(typeof(IMediator));
            Setup();
        }

        public void Setup()
        {
            var reservoirs = Reservoirs();
            foreach (var reservoir in reservoirs)
            {
                _mediator.Send(reservoir);
            }
        }

        [Fact]
        public void GetAllReservoirs_ShouldSuccessfullyGetAllReservoirs()
        {
            var reservoirs = _mediator.Send(new GetAllReservoirListRequest()).Result;

            reservoirs.Should().HaveCount(2);
        }


        [Fact]
        public void CreateReservoir_ShouldSuccessfullyCreateReservoir()
        {
            var createReservoirRequest = new CreateReservoirRequest
            {
                Name = "Akos",
                UtimateRecovery = 2.0,
                Temperature = 3.0,
                STOIIP = 4.0,
                PressureDatumDepth = 4.0,
                InitialReservoirPressure = 5.0,
                OriginalGasCapRatio = 6.0,
                ResevoirFluidType = "water",
                AquiferParameter = new CreateReservoirRequest.AquiferParametersDto
                {
                    AquiferModel = "a",
                    AquiferPermeability = 7.0,
                    Encroachmentangle = 8.0,
                    OuterInnerRadiusRatio = 9.0,
                    ReservoirRadius = 10.0
                },
                BHP = new CreateReservoirRequest.BHPDto
                {
                    Date = DateTime.Now,
                    DrainagePoint = "pecon-001",
                    Pressure = 11.0
                },
                Impurities = new CreateReservoirRequest.ImpuritiesDto
                {
                    CO2 = 12.0,
                    H2S = 13.0,
                    N2 = 14.0
                },
                PVT = new CreateReservoirRequest.PVTDto
                {
                    ModelType = "good",
                    RsandBo = "bad",
                    Viscosity = "ok"
                },
                Rock = new CreateReservoirRequest.RockDto
                {
                    ResidualFluidSaturation = new CreateReservoirRequest.RockDto.ResidualFluidSaturationDto
                    {
                        Gas = 15.0,
                        Oil = 16.0,
                        Water = 17.0
                    },
                    RockPorosity = new CreateReservoirRequest.RockDto.RockPorosityDto
                    {
                        ReservoirPermeability = 18.0,
                        ReservoirPorosity = 19.0
                    }
                }
            };

            var result = _mediator.Send(createReservoirRequest).Result;

            var reservoirs = _mediator.Send(new GetAllReservoirListRequest()).Result;

            result.Should().Be(3);
            reservoirs.Should().HaveCount(3);
        }

        [Fact]
        public void UpdateReservoir_ShouldUpdateReservoirSuccessfully()
        {
            var updateReservoirRequest = new UpdateReservoirRequest
            {
                Id = 1,
                Name = "INCA",
                UtimateRecovery = 2.0,
                Temperature = 3.0,
                STOIIP = 4.0,
                PressureDatumDepth = 4.0,
                InitialReservoirPressure = 5.0,
                OriginalGasCapRatio = 6.0,
                ResevoirFluidType = "water",
                AquiferParameter = new UpdateReservoirRequest.AquiferParametersDto
                {
                    AquiferModel = "a",
                    AquiferPermeability = 7.0,
                    Encroachmentangle = 8.0,
                    OuterInnerRadiusRatio = 9.0,
                    ReservoirRadius = 10.0
                },
                BHP = new UpdateReservoirRequest.BHPDto
                {
                    Date = DateTime.Now,
                    DrainagePoint = "pecon-001",
                    Pressure = 11.0
                },
                Impurities = new UpdateReservoirRequest.ImpuritiesDto
                {
                    CO2 = 12.0,
                    H2S = 13.0,
                    N2 = 14.0
                },
                PVT = new UpdateReservoirRequest.PVTDto
                {
                    ModelType = "good",
                    RsandBo = "bad",
                    Viscosity = "ok"
                },
                Rock = new UpdateReservoirRequest.RockDto
                {
                    ResidualFluidSaturation = new UpdateReservoirRequest.RockDto.ResidualFluidSaturationDto
                    {
                        Gas = 15.0,
                        Oil = 16.0,
                        Water = 17.0
                    },
                    RockPorosity = new UpdateReservoirRequest.RockDto.RockPorosityDto
                    {
                        ReservoirPermeability = 18.0,
                        ReservoirPorosity = 19.0
                    }
                }
            };

            var result = _mediator.Send(updateReservoirRequest).Result;
            var updatedReservoir = _mediator.Send(new GetReservoirByIdRequest { Id = 1 }).Result;

            result.Should().Be(1);
            updatedReservoir.Should().NotBeNull();
            updatedReservoir.Name.Should().Be("INCA");
        }

        [Fact]
        public void DeleteReservoir_ShouldDeleteAReservoirSuccessfully()
        {
            var deleteReservoirRequest = new DeleteReservoirRequest { Id = 1 };

            _mediator.Send(deleteReservoirRequest).Wait();


            var deletedReservoir = _mediator.Send(new GetReservoirByIdRequest { Id = 1 }).Result;
            var reservoirs = _mediator.Send(new GetAllReservoirListRequest()).Result;

            deletedReservoir.Should().BeNull();
            reservoirs.Should().HaveCount(1);
        }


        private List<CreateReservoirRequest> Reservoirs()
        {
            var reservoirs = new List<CreateReservoirRequest>();
            var reservoir1 = new CreateReservoirRequest
            {
                Name = "Pecon1",
                UtimateRecovery = 2.0,
                Temperature = 3.0,
                STOIIP = 4.0,
                PressureDatumDepth = 4.0,
                InitialReservoirPressure = 5.0,
                OriginalGasCapRatio = 6.0,
                ResevoirFluidType = "water",
                AquiferParameter = new CreateReservoirRequest.AquiferParametersDto
                {
                    AquiferModel = "a",
                    AquiferPermeability = 7.0,
                    Encroachmentangle = 8.0,
                    OuterInnerRadiusRatio = 9.0,
                    ReservoirRadius = 10.0
                },
                BHP = new CreateReservoirRequest.BHPDto
                {
                    Date = DateTime.Now,
                    DrainagePoint = "pecon-001",
                    Pressure = 11.0
                },
                Impurities = new CreateReservoirRequest.ImpuritiesDto
                {
                    CO2 = 12.0,
                    H2S = 13.0,
                    N2 = 14.0
                },
                PVT = new CreateReservoirRequest.PVTDto
                {
                    ModelType = "good",
                    RsandBo = "bad",
                    Viscosity = "ok"
                },
                Rock = new CreateReservoirRequest.RockDto
                {
                    ResidualFluidSaturation = new CreateReservoirRequest.RockDto.ResidualFluidSaturationDto
                    {
                        Gas = 15.0,
                        Oil = 16.0,
                        Water = 17.0
                    },
                    RockPorosity = new CreateReservoirRequest.RockDto.RockPorosityDto
                    {
                        ReservoirPermeability = 18.0,
                        ReservoirPorosity = 19.0
                    }
                }
            };

            var reservoir2 = new CreateReservoirRequest
            {
                Name = "PECON2",
                UtimateRecovery = 2.0,
                Temperature = 3.0,
                STOIIP = 4.0,
                PressureDatumDepth = 4.0,
                InitialReservoirPressure = 5.0,
                OriginalGasCapRatio = 6.0,
                ResevoirFluidType = "water",
                AquiferParameter = new CreateReservoirRequest.AquiferParametersDto
                {
                    AquiferModel = "a",
                    AquiferPermeability = 7.0,
                    Encroachmentangle = 8.0,
                    OuterInnerRadiusRatio = 9.0,
                    ReservoirRadius = 10.0
                },
                BHP = new CreateReservoirRequest.BHPDto
                {
                    Date = DateTime.Now,
                    DrainagePoint = "pecon-001",
                    Pressure = 11.0
                },
                Impurities = new CreateReservoirRequest.ImpuritiesDto
                {
                    CO2 = 12.0,
                    H2S = 13.0,
                    N2 = 14.0
                },
                PVT = new CreateReservoirRequest.PVTDto
                {
                    ModelType = "good",
                    RsandBo = "bad",
                    Viscosity = "ok"
                },
                Rock = new CreateReservoirRequest.RockDto
                {
                    ResidualFluidSaturation = new CreateReservoirRequest.RockDto.ResidualFluidSaturationDto
                    {
                        Gas = 15.0,
                        Oil = 16.0,
                        Water = 17.0
                    },
                    RockPorosity = new CreateReservoirRequest.RockDto.RockPorosityDto
                    {
                        ReservoirPermeability = 18.0,
                        ReservoirPorosity = 19.0
                    }
                }
            };

            reservoirs.Add(reservoir1);
            reservoirs.Add(reservoir2);

            return reservoirs;
        }
    }
}
