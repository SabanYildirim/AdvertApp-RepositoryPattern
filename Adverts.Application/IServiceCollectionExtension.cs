using Adverts.Application.Interfaces;
using Adverts.Application.Services;
using Adverts.Core.Mapping;
using Adverts.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Producer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Application
{
    public static class IServiceCollectionExtension
    {
        public static IServiceProvider ServiceProvider;

        public static IServiceCollection RegisterAdvertsService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IAdvertsServices, AdvertsService>();
            services.AddTransient<IAdvertVisitServices, AdvertVisitServices>();
            services.AddTransient<IMappingBase, MappingBase>();
            services.AddTransient<IQueueServices, QueuesSender>();
            services.AddInfrastructure();

            ServiceProvider = services.BuildServiceProvider();

            return services;
        }
    }
}
