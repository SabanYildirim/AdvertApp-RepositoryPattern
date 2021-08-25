using Adverts.Application.Model.DTO;
using Adverts.Application.Model.DTO.Response;
using Adverts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Application.Interfaces
{
    public interface IAdvertsServices 
    {
        Task<BaseServiceResponseModel<AdvertResponseModel>> GetAllAsync(FilteringModel filtering, SortingModel sorting);
        Task<BaseServiceResponseModel<AdvertDetailResponseModel>> GetByIdAsync(int id);
    }
}
