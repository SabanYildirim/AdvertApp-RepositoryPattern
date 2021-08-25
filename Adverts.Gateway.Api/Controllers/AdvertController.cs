using Adverts.Application.Interfaces;
using Adverts.Application.Model.DTO;
using Adverts.Application.Model.DTO.Response;
using Adverts.Core.Models;
using Adverts.Gateway.Api.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Adverts.Gateway.Api
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertsServices _advertsService;
        private readonly IAdvertVisitServices _advertVisitService;
        private readonly IHeaderClientIp _headerIp;
        public AdvertController(
            IAdvertsServices advertsServices,
            IAdvertVisitServices advertVisitService,
            IHeaderClientIp headerIp
            )
        {
            _advertsService = advertsServices;
            _advertVisitService = advertVisitService;
            _headerIp = headerIp;
        }

        [HttpGet("/getall")]
        public async Task<BaseServiceResponseModel<AdvertResponseModel>> GetAll([FromQuery] FilteringModel filtering, [FromQuery] SortingModel sorting)
        {
            return await _advertsService.GetAllAsync(filtering, sorting);
        }

        [HttpGet("/get")]
        public async Task<BaseServiceResponseModel<AdvertDetailResponseModel>> Get([FromQuery] int Id)
        {
            return await _advertsService.GetByIdAsync(Id);
        }

        [HttpPost("/visit")]
        public async Task<bool> visit(int advertId)
        {
            return await _advertVisitService.AdvertVisitSendQueues(advertId, _headerIp.IPAddress.ToString());
        }
    }
}
