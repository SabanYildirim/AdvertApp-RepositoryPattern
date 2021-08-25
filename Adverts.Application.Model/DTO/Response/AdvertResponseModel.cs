using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Application.Model.DTO.Response
{
    public class AdvertResponseModel
    {
        public string id { get; set; }
        public string modelName { get; set; }
        public string category { get; set; }
        public string year { get; set; }
        public string price { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string km { get; set; }
        public string color { get; set; }
        public string gear { get; set; }
        public string fuel { get; set; }
        public string firstPhoto { get; set; }
    }
}
