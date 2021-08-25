using Adverts.Application.Services;
using Adverts.Application.Interfaces;
using Adverts.Application.Model.DTO;
using Adverts.Application.Model.DTO.Response;
using Adverts.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Adverts.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Adverts.Core.Models;
using RabbitMQ.Producer;

namespace Adverts.Application.Services
{
    public class AdvertsService : IAdvertsServices
    {
        private readonly IMappingBase _mapper;
        private readonly IAdvertsRepository _IadvertsRepository;

        public AdvertsService(
            IAdvertsRepository advertsRepository,
            IMappingBase mapper
            )
        {
            _IadvertsRepository = advertsRepository;
            _mapper = mapper;
        }

        public async Task<BaseServiceResponseModel<AdvertResponseModel>> GetAllAsync(FilteringModel filtering, SortingModel sorting)
        {
            try
            {
                var advertsEntities = await _IadvertsRepository.GetAllAsync(filtering, sorting);

                var advertsResponse = _mapper.Map<List<AdvertResponseModel>>(advertsEntities);
                if (advertsResponse == null || !advertsResponse.Any())
                {
                    return new BaseServiceResponseModel<AdvertResponseModel>
                    {
                        responseCode = HttpStatusCode.NoContent.GetHashCode(),
                    };
                }

                return new BaseServiceResponseModel<AdvertResponseModel>
                {
                    responseCode = HttpStatusCode.OK.GetHashCode(),
                    total = advertsEntities.FirstOrDefault().totalCount,
                    page = filtering.page,
                    adverts = advertsResponse.ToList(),
                };
            }

            catch (Exception ex)
            {
                return new BaseServiceResponseModel<AdvertResponseModel>
                {
                    responseCode = HttpStatusCode.InternalServerError.GetHashCode(),
                };
            }
        }

        public async Task<BaseServiceResponseModel<AdvertDetailResponseModel>> GetByIdAsync(int id)
        {
            try
            {
                var advertEntitiy = await _IadvertsRepository.GetByIdAsync(id);
                var advertDetail = _mapper.Map<AdvertDetailResponseModel>(advertEntitiy);
                if (advertDetail == null)
                {
                    return new BaseServiceResponseModel<AdvertDetailResponseModel>
                    {
                        responseCode = HttpStatusCode.NoContent.GetHashCode(),
                    };
                }

                return new BaseServiceResponseModel<AdvertDetailResponseModel>
                {
                    responseCode = HttpStatusCode.OK.GetHashCode(),
                    adverts = new List<AdvertDetailResponseModel>
                    {
                      advertDetail
                    },
                };
            }
            catch (Exception ex)
            {
                return new BaseServiceResponseModel<AdvertDetailResponseModel>
                {
                    responseCode = HttpStatusCode.InternalServerError.GetHashCode(),
                };
            }
        }
    }
}
