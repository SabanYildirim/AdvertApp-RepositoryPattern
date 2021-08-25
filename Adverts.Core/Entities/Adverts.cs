using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Entities
{
    public class Adverts
    {
        public string id { get; set; }
        public string memberId { get; set; }
        public string cityId { get; set; }
        public string cityName { get; set; }
        public string townId { get; set; }
        public string townName { get; set; }
        public string modelId { get; set; }
        public string modelName { get; set; }
        public string year { get; set; }
        public string price { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string categoryId { get; set; }
        public string category { get; set; }
        public string km { get; set; }
        public string color { get; set; }
        public string gear { get; set; }
        public string fuel { get; set; }
        public string firstPhoto { get; set; }
        public string secondPhoto { get; set; }
        public string userInfo { get; set; }
        public string userPhone { get; set; }
        public string text { get; set; }
        public int totalCount { get; set; }
    }
}
