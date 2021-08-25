using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Base
{
    public interface IRabbitMQBase
    {
        void CreateConnection();
        bool ConnectionExists();
        IModel CreateModel();
    }
}
