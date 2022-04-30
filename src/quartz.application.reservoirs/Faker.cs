using quartz.wpf.common.AuthModel;
using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.application.reservoirs
{
    public static class Faker
    {
        public static Reservoir GetReservoir()
        {
            return new Reservoir()
            {
                Name = "A reservoir name",
                ResevoirFluidType = "Oil + Gas",
                InitialReservoirPressure = 552.0,
                Temperature = 68.0,
                OriginalGasCapRatio = 62.89,
                PressureDatumDepth = 65.0,
                STOIIP = 542.0,
                UtimateRecovery = 452.0,
                AquiferParameter = new AquiferParameters
                {
                    AquiferModel="model",
                    AquiferPermeability=58,
                    Encroachmentangle=52,
                    OuterInnerRadiusRatio=56,
                    ReservoirRadius=5
                },
                BHP = new BHP
                {
                    Date = DateTime.Now,
                    DrainagePoint="drainagePoint",
                    Pressure=2515
                },
                Impurities = new Impurities
                {
                    CO2=25,
                    H2S=56,
                    N2=63
                },
                Rock = new Rock
                {
                    ResidualFluidSaturation = new ResidualFluidSaturation() { Gas=52, Oil=52,Water=52},
                    RockPorosity = new RockPorosity { ReservoirPermeability=52, ReservoirPorosity=225}
                },
                PVT = new PVT
                {
                    ModelType="Gas + Condensate",
                    RsandBo="Hurst Van Everdingen SP2",
                    Viscosity="Hydrocarbon"
                },
                User = new User
                {
                    Email="some@gmail.com",
                    Firstname="Eadwin",
                    Lastname="Kuro"
                }
            };
        }

        public static List<ReservoirIndexResponse> GetReservoirIndexes()
        {
            return new List<ReservoirIndexResponse>()
            {
                new ReservoirIndexResponse{ReservoirId=1, ReservoirName="Reservoir1", User=GetUser("Daniel","Kuro")},
                new ReservoirIndexResponse{ReservoirId=1, ReservoirName="Reservoir2", User=GetUser("Kuro","Eadwin")},
                new ReservoirIndexResponse{ReservoirId=1, ReservoirName="Reservoir3", User=GetUser("Daniel","Dakolo")},
                new ReservoirIndexResponse{ReservoirId=1, ReservoirName="Reservoir4", User=GetUser("Eadwin","Kuro")},
            };
        }

        private static User GetUser(string FirstName, string LastName )
        {
            return new User { Email = $"{FirstName.ToLower()}.{LastName.ToLower()}@cyphercrescent.com", Firstname = FirstName, Lastname = LastName };
        }
    }
}
