using FluentAssertions;
using Quartz.Application.Reservoirs.Interfaces;
using Quartz.Core.Domain.Test;
using Quartz.Domain.Reservoirs;
using System;
using System.Collections.Generic;
using Xunit;

namespace Quartz.Core.Domain.ReservoirTest
{
    public class ReservoirRepositoryTest : BaseSetup
    {
        private readonly IReservoirRepository _reservoirRepository;
        public ReservoirRepositoryTest()
        {
            _reservoirRepository = (IReservoirRepository)ServiceProvider.GetService(typeof(IReservoirRepository));
            Setup();
        }

        public void Setup()
        {
            var reservoirs = Reservoirs();
            foreach(var reservoir in reservoirs)
            {
                _reservoirRepository.Save(reservoir);
            }

            _reservoirRepository.Transaction.Commit();
        }

        [Fact]
        public void GetAll_ShouldReturnAllReservoirSuccessfullyFromDatabase()
        {
            var reservoirs = _reservoirRepository.GetAll();
            reservoirs.Should().HaveCount(2);
        }

        [Fact]
        public void CreateReservoir_ShouldCreateReservoirSuccessfully()
        {
            var reservoir = new Reservoir
            {
                Name = "Akos",
                UtimateRecovery = 2.0,
                Temperature = 3.0,
                STOIIP = 4.0,
                PressureDatumDepth = 4.0,
                InitialReservoirPressure = 5.0,
                OriginalGasCapRatio = 6.0,
                ResevoirFluidType = "water",
                AquiferParameter = new AquiferParameters
                {
                    AquiferModel = "a",
                    AquiferPermeability = 7.0,
                    Encroachmentangle = 8.0,
                    OuterInnerRadiusRatio = 9.0,
                    ReservoirRadius = 10.0
                },
                BHP = new BHP
                {
                    Date = DateTime.Now,
                    DrainagePoint = "pecon-001",
                    Pressure = 11.0
                },
                Impurities = new Impurities
                {
                    CO2 = 12.0,
                    H2S = 13.0,
                    N2 = 14.0
                },
                PVT = new PVT
                {
                    ModelType = "good",
                    RsandBo = "bad",
                    Viscosity = "ok"
                },
                Rock = new Rock
                {
                    ResidualFluidSaturation = new ResidualFluidSaturation
                    {
                        Gas = 15.0,
                        Oil = 16.0,
                        Water = 17.0
                    },
                    RockPorosity = new RockPorosity
                    {
                        ReservoirPermeability = 18.0,
                        ReservoirPorosity = 19.0
                    }
                }
            };


            _reservoirRepository.Save(reservoir);
            _reservoirRepository.Transaction.Commit();

            var reservoirs = _reservoirRepository.GetAll();
            reservoirs.Should().HaveCount(3);
        }

        [Fact]
        public void UpdateReservoir_ShouldUpdateReservoirSuccessfully()
        {
            var reservoir = _reservoirRepository.GetById(1);
            reservoir.Name = "INCA";

            _reservoirRepository.Update(reservoir);
            _reservoirRepository.Transaction.Commit();

            var updatedReservoir = _reservoirRepository.GetById(1);

            updatedReservoir.Should().NotBeNull();
            updatedReservoir.Name.Should().Be("INCA");
        }

        [Fact]
        public void DeleteReservoir_ShouldDeleteAReservoirSuccessfully()
        {
            var reservoir = _reservoirRepository.GetById(1);

            _reservoirRepository.Delete(reservoir);
            _reservoirRepository.Transaction.Commit();

            var deletedReservoir = _reservoirRepository.GetById(1);
            var reservoirs = _reservoirRepository.GetAll();

            deletedReservoir.Should().BeNull();
            reservoirs.Should().HaveCount(1);
        }

        [Fact]
        public void GetById_ShouldSuccessfullyGetReservoir_WhenAValidIdArgumentIsSupplied()
        {
            var reservoir = _reservoirRepository.GetById(1);

            reservoir.Should().NotBeNull();
            reservoir.Name.Should().Be("Pecon1");
        }

        [Fact]
        public void GetById_ShouldFailToGetReservoir_WhenAnInValidIdArgumentIsSupplied()
        {
            var reservoir = _reservoirRepository.GetById(0);

            reservoir.Should().BeNull();
        }

        [Fact]
        public void GetByName_ShouldSuccessfullyGetReservoir_WhenAValidNameArgumentIsSupplied()
        {
            var reservoir = _reservoirRepository.GetByName("Pecon1");

            reservoir.Should().NotBeNull();
            reservoir.Name.Should().Be("Pecon1");
        }

        [Fact]
        public void GetByName_ShouldSuccessfullyGetReservoir_WhenAValidNameArgumentInLowerCaseIsSupplied()
        {
            var reservoir = _reservoirRepository.GetByName("pecon2");

            reservoir.Should().NotBeNull();
            reservoir.Name.Should().Be("PECON2");
        }

        [Fact]
        public void GetByName_ShouldFailToGetReservoir_WhenAnInValidNameArgumentIsSupplied()
        {
            var reservoir = _reservoirRepository.GetByName("Dakolo");

            reservoir.Should().BeNull();
        }

        private List<Reservoir> Reservoirs()
        {
            var reservoirs = new List<Reservoir>();
            var reservoir1 = new Reservoir
            {
                Name = "Pecon1",
                UtimateRecovery = 2.0,
                Temperature = 3.0,
                STOIIP = 4.0,
                PressureDatumDepth = 4.0,
                InitialReservoirPressure = 5.0,
                OriginalGasCapRatio = 6.0,
                ResevoirFluidType = "water",
                AquiferParameter = new AquiferParameters
                {
                    AquiferModel = "a",
                    AquiferPermeability = 7.0,
                    Encroachmentangle = 8.0,
                    OuterInnerRadiusRatio = 9.0,
                    ReservoirRadius = 10.0
                },
                BHP = new BHP
                {
                    Date = DateTime.Now,
                    DrainagePoint = "pecon-001",
                    Pressure = 11.0
                },
                Impurities = new Impurities
                {
                    CO2 = 12.0,
                    H2S = 13.0,
                    N2 = 14.0
                },
                PVT = new PVT
                {
                    ModelType = "good",
                    RsandBo = "bad",
                    Viscosity = "ok"
                },
                Rock = new Rock
                {
                    ResidualFluidSaturation = new ResidualFluidSaturation
                    {
                        Gas = 15.0,
                        Oil = 16.0,
                        Water = 17.0
                    },
                    RockPorosity = new RockPorosity
                    {
                        ReservoirPermeability = 18.0,
                        ReservoirPorosity = 19.0
                    }
                }
            };

            var reservoir2 = new Reservoir
            {
                Name = "PECON2",
                UtimateRecovery = 2.0,
                Temperature = 3.0,
                STOIIP = 4.0,
                PressureDatumDepth = 4.0,
                InitialReservoirPressure = 5.0,
                OriginalGasCapRatio = 6.0,
                ResevoirFluidType = "water",
                AquiferParameter = new AquiferParameters
                {
                    AquiferModel = "a",
                    AquiferPermeability = 7.0,
                    Encroachmentangle = 8.0,
                    OuterInnerRadiusRatio = 9.0,
                    ReservoirRadius = 10.0
                },
                BHP = new BHP
                {
                    Date = DateTime.Now,
                    DrainagePoint = "pecon-001",
                    Pressure = 11.0
                },
                Impurities = new Impurities
                {
                    CO2 = 12.0,
                    H2S = 13.0,
                    N2 = 14.0
                },
                PVT = new PVT
                {
                    ModelType = "good",
                    RsandBo = "bad",
                    Viscosity = "ok"
                },
                Rock = new Rock
                {
                    ResidualFluidSaturation = new ResidualFluidSaturation
                    {
                        Gas = 15.0,
                        Oil = 16.0,
                        Water = 17.0
                    },
                    RockPorosity = new RockPorosity
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
