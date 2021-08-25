using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Entities
{
    public class AdvertVisits
    {
        public int advertId { get; set; }
        public string ipAdress { get; set; }
        public DateTime visitDate { get; set; }
    }
}
