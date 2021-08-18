using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Producer
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection RegisterRabbitMQProduver(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IQueueServices, QueuesSender>();
      
            return services;
        }
    }
}
