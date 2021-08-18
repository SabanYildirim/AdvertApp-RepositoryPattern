using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Base;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    public class QueuesSender : IQueueServices
    {
        private IConnection _connection;

        private readonly IConfiguration _configuration;
        private IRabbitMQBase _rabbitMQBase;

        public QueuesSender
            (IConfiguration configuration,
             IRabbitMQBase rabbitMQBase
            )
        {
            _configuration = configuration;
            _rabbitMQBase = rabbitMQBase;

            _rabbitMQBase.CreateConnection();
        }

        public async Task<bool> SendVisit(Adverts.Core.Entities.AdvertVisits adverVisit)
        {
            try
            {
                if (_rabbitMQBase.ConnectionExists())
                {
                    using (var channel = _rabbitMQBase.CreateModel())
                    {
                        channel.QueueDeclare(_configuration["QueuesConfig:HostName"].ToString(),
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(adverVisit));
                        channel.BasicPublish("", _configuration["QueuesConfig:QueueName"].ToString(), null, body);
                    }
                }

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
