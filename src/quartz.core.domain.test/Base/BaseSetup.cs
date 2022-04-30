using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Application.Reservoirs.CommandInteractors;
using Quartz.Application.Reservoirs.Interfaces;
using Quartz.Persistence.Nhibernate;
using Quartz.Persistence.Nhibernate.Reservoirs;

namespace Quartz.Core.Domain.Test
{
    public class BaseSetup
    {
        public BaseSetup()
        {
            var services = new ServiceCollection();

            services.AddSingleton<INhibernateSessionFactory, NhibernateSessionFactoryTest>();
            services.AddSingleton<INhibernateTransaction, NhibernateTransactionTest>();
            services.AddSingleton<IReservoirRepository, ReservoirRepository>();
            services.AddSingleton<IReservoirQueries, ReservoirQueries>();
            services.AddMediatR(typeof(CreateReservoirInteractor).Assembly);

            ServiceProvider = services.BuildServiceProvider();
        }

        protected ServiceProvider ServiceProvider { get; }
    }
}
