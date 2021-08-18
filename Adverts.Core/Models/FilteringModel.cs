using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Models
{
    public class FilteringModel
    {
        public int categoryId { get; set; }
        public int price { get; set; }
        public string gear { get; set; }
        public string fuel { get; set; }
        public int page { get; set; }
    }
}
