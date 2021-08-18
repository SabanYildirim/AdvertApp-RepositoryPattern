using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Application.Interfaces
{
    public interface IAdvertVisitServices
    {
        Task<bool> AdvertVisitSendQueues(int advertId,string ip);
        Task<int> AddAdvertVisit(Adverts.Core.Entities.AdvertVisits advertVisits);
    }
}
