using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Base
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection RegisterRabbitMQBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IRabbitMQBase, RabbitMQBase>();
   
            return services;
        }
    }
}
