using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Quartz.Domain.Reservoirs;
using Quartz.Domain.Users;
using Quartz.Persistence.Nhibernate.Mappings;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace Quartz.Persistence.Nhibernate
{
    public class NhibernateSessionFactory : INhibernateSessionFactory
    {
        private ISessionFactory _sessionFactory;
        private readonly string _connectionString;

        public NhibernateSessionFactory(string connectionString)
        {
            _connectionString = connectionString;
            InitializeSessionFactoryForSqlite();
            Seed();
        }

        public ISessionFactory SessionFactory()
        {
            return _sessionFactory;
        }

        private void InitializeSessionFactoryForSqlServer()
        {
            string commandTimeoutValue = "100000";
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                                .ConnectionString(_connectionString))
                .Mappings(m =>
                            m.FluentMappings
                                .AddFromAssemblyOf<ReservoirMap>())
                .ExposeConfiguration(cfg =>
                {
                    new SchemaExport(cfg).Create(false, false);
                    cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, commandTimeoutValue);
                    NHibernate.Cfg.Environment.Properties.Add(NHibernate.Cfg.Environment.CommandTimeout,
                        commandTimeoutValue);
                })
                .BuildSessionFactory();

            _sessionFactory = sessionFactory;
        }

        private void InitializeSessionFactoryForSqlite()
        {
            string commandTimeoutValue = "100000";
            var sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                                .ConnectionString(_connectionString))
                .Mappings(m =>
                            m.FluentMappings
                                .AddFromAssemblyOf<ReservoirMap>())
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(true, true);
                    cfg.SetProperty(NHibernate.Cfg.Environment.CommandTimeout, commandTimeoutValue);
                    NHibernate.Cfg.Environment.Properties.Add(NHibernate.Cfg.Environment.CommandTimeout,
                        commandTimeoutValue);
                })
                .BuildSessionFactory();

            _sessionFactory = sessionFactory;
        }

        private void WriteToJson()
        {
            List<Reservoir> reservoirs = new List<Reservoir>();
            using (var session = _sessionFactory.OpenSession())
            {
                reservoirs = session.Query<Reservoir>().ToList();
            }

            var location = Environment.CurrentDirectory;
            using (StreamWriter file = File.CreateText($"{location}/reservoirs.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, reservoirs);
            }
        }

        private void Seed()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                int count = 0;
                try
                {
                    count = session.QueryOver<Reservoir>()
                                .Select(Projections.RowCount())
                                .FutureValue<int>()
                                .Value;
                }
                catch (NHibernate.Exceptions.GenericADOException)
                {

                }

                if (count > 0)
                {
                    return;
                }

                for (int i = 0; i < 200; i++)
                {
                    var reservoir = Reservoir($"Reservoir {i + 1}");
                    session.Save(reservoir);
                }

                var user = User("Steven");
                session.Save(user);

                using (var trans = session.BeginTransaction())
                {
                    trans.Commit();
                }
            }
        }

        private User User(string name)
        {
            return new User
            {
                FirstName = name,
                LastName = "Daniel",
                UserName = "steve.daniel",
                Email = "steven.daniel@cyphercrescent.com",
                Password = "stevendaniel"
            };
        }

        private Reservoir Reservoir(string name)
        {
            return new Reservoir
            {
                Name = name,
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
        }
    }
}
