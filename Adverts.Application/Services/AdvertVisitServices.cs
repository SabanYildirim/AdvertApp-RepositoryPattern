using Adverts.Application.Interfaces;
using Adverts.Application.Model.DTO;
using Adverts.Infrastructure.Interfaces;
using RabbitMQ.Producer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Application.Services
{
    public class AdvertVisitServices : IAdvertVisitServices
    {
        private readonly IAdvertVisitRepository _IadvertsVisitRepository;
        private readonly IQueueServices _IQueueServices;

        public AdvertVisitServices(
            IAdvertVisitRepository advertsVisitRepository,
            IQueueServices IQueueServices
            )
        {
            _IadvertsVisitRepository = advertsVisitRepository;
            _IQueueServices = IQueueServices;
        }

        public async Task<bool> AdvertVisitSendQueues(int advertId, string ip)
        {
            try
            {
                Adverts.Core.Entities.AdvertVisits advertVisitModel = new Adverts.Core.Entities.AdvertVisits();
                advertVisitModel.advertId = advertId;
                advertVisitModel.ipAdress = ip;
                advertVisitModel.visitDate = DateTime.Now;
                
                await _IQueueServices.SendVisit(advertVisitModel);
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<int> AddAdvertVisit(Adverts.Core.Entities.AdvertVisits advertVisits)
        {
            try
            {
                return await _IadvertsVisitRepository.AddAsync(advertVisits);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
