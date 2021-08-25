using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAdvertVisitQueue _advertVisitQueue;

        public Worker(
            ILogger<Worker> logger,
            IAdvertVisitQueue advertVisitQueue
            )
        {
            _logger = logger;
            _advertVisitQueue = advertVisitQueue;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _advertVisitQueue.Run();
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }
    }
}
