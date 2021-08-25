using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Models
{
    public class Pageable
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int Offset { get; set; }
        public int Next { get; set; }

        public Pageable(int page, int pageSize = 100)
        {
            Page = page < 1 ? 1 : page;
            PageSize = pageSize < 1 ? 10 : pageSize;

            Next = pageSize;
            Offset = (Page - 1) * Next;
        }
    }
}
