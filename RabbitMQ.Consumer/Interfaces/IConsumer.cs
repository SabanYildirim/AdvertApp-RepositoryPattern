using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer
{
    public interface IConsumer
    {
        void Consume();
    }
}
