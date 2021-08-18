using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Mapping
{
    public interface IMappingBase
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
