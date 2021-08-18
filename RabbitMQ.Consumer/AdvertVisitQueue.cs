using Adverts.Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Consumer
{
    public class AdvertVisitQueue : IAdvertVisitQueue
    {
        private readonly IConsumer _consumer;
        private readonly IAdvertVisitServices _advertVisitServicesa;
        public AdvertVisitQueue
            (IConsumer consumer,
            IAdvertVisitServices advertVisitServicesa
            )
        {
            _consumer = consumer;
            _advertVisitServicesa = advertVisitServicesa;
        }

        public void Run()
        {
            _consumer.Consume();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
