using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Base
{
    public class RabbitMQBase : IRabbitMQBase
    {
        private readonly IConfiguration configuration;
        private IConnection _connection;
      
        public RabbitMQBase(IConfiguration configuration)
        {         
            this.configuration = configuration;
        }

        public bool IsConnection => _connection != null && _connection.IsOpen;

        public IModel CreateModel()
        {
            return _connection.CreateModel();
        }

        public void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(configuration["QueuesConfig:HostName"].ToString()),
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        public bool ConnectionExists()
        {
            if (IsConnection)
            {
                return true;
            }

            CreateConnection();
            return IsConnection;
        }
    }
}
