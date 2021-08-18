using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Consumer
{
    public interface IAdvertVisitQueue
    {
        void Run();
        void Stop();
    }
}
