﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Application.Reservoirs.CommandInteractors;

namespace Quartz.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateReservoirInteractor).Assembly);

            return services;
        }
    }
}
