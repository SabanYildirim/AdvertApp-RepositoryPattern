using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Application.Model.DTO
{
    public class BaseServiceResponseModel<T> where T : class,new()
    {
        public int responseCode { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public IEnumerable<T> adverts { get; set; }
    }
}
