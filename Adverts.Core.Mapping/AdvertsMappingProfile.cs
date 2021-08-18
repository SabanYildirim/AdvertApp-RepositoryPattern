using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Mapping
{
    public class AdvertsMappingProfile : Profile
    {
        public AdvertsMappingProfile()
        {
            CreateMap<Adverts.Core.Entities.Adverts,Adverts.Application.Model.DTO.Response.AdvertResponseModel>().ReverseMap();
            CreateMap<Adverts.Core.Entities.Adverts, Adverts.Application.Model.DTO.Response.AdvertDetailResponseModel>().ReverseMap();
        }
    }
}
