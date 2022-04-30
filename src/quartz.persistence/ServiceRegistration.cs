using Microsoft.Extensions.DependencyInjection;
using quartz.application.Users.Interfaces;
using quartz.persistence.nhibernate.Users;
using Quartz.Application.Reservoirs.Interfaces;
using Quartz.Persistence.Nhibernate.Reservoirs;

namespace Quartz.Persistence.Nhibernate
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddNhibernatePersistence(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<INhibernateSessionFactory>(x => new NhibernateSessionFactory(connectionString));
            services.AddScoped<INhibernateTransaction, NHibernateTransaction>();
            services.AddScoped<IReservoirRepository, ReservoirRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReservoirQueries, ReservoirQueries>();
            services.AddScoped<IUserQueries, UserQueries>();

            return services;
        }
    }
}
