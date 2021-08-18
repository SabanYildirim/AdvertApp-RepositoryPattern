using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Adverts.Gateway.Api.Middleware
{
    public interface IHeaderClientIp
    {
        IPAddress IPAddress { get; set; }
    }

    public class ClientIPAddress : IHeaderClientIp
    {
        public IPAddress IPAddress { get; set; }
    }

}
