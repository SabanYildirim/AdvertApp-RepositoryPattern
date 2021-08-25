using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Mapping
{
    public class MappingBase : IMappingBase
    {
        private IMapper _mapper;
        public MappingBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
