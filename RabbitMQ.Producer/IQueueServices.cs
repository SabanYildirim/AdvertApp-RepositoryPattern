using Adverts.Application.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    public interface IQueueServices
    {
        Task<bool> SendVisit(Adverts.Core.Entities.AdvertVisits adverVisit);
    }
}
