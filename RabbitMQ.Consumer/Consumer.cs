using Adverts.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Base;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer
{
    public class Consumer : IConsumer
    {
        private readonly IConfiguration _configuration;

        private IAdvertVisitServices _advertVisitServices;
        private IRabbitMQBase _rabbitMQBase;

        public Consumer(
            IAdvertVisitServices advertVisitServices,
            IConfiguration configuration,
            IRabbitMQBase rabbitMQBase
            )
        {
            _advertVisitServices = advertVisitServices;
            _configuration = configuration;
            _rabbitMQBase = rabbitMQBase;

            _rabbitMQBase.CreateConnection();
        }

        public void Consume()
        {
            string consumeModel = string.Empty;
            try
            {
                if (_rabbitMQBase.ConnectionExists())
                {
                    using (var channel = _rabbitMQBase.CreateModel())
                    {
                        var consumer = new EventingBasicConsumer(channel);

                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);

                            Console.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", _configuration["QueuesConfig:QueueName"].ToString(), message);

                            var resultModel = JsonConvert.DeserializeObject<Adverts.Core.Entities.AdvertVisits>(message);
                            if (resultModel != null)
                            _advertVisitServices.AddAdvertVisit(resultModel);
                        };

                        channel.BasicConsume(_configuration["QueuesConfig:QueueName"].ToString(), true, consumer);
                        Console.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
               
            }
        }
    }
}
