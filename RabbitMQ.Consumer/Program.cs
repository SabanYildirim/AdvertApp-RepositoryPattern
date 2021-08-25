using Adverts.Application;
using Adverts.Core.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Base;
using System;


namespace RabbitMQ.Consumer
{
    public class Program
    {
        public static IServiceProvider ServiceProvider;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IAdvertVisitQueue, AdvertVisitQueue>();
                    services.AddTransient<IConsumer, Consumer>();

                    services.RegisterAdvertsService(hostContext.Configuration);
                    services.RegisterMappingProfiles();
                    services.RegisterRabbitMQBase(hostContext.Configuration);

                    ServiceProvider = services.BuildServiceProvider();
                });
    }
}
