using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Adverts.Gateway.Api.Middleware
{
    public class HttpHeaderOptionsMiddleware
    {
        private readonly RequestDelegate _next;
        public HttpHeaderOptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IHeaderClientIp clientIp)
        {
          
            var headers = context.Request.Headers.ToList();
            if (headers.Exists((kvp) => kvp.Key == "X-Forwarded-For"))
            {
                var header = headers.First((kvp) => kvp.Key == "X-Forwarded-For").Value.ToString();
                clientIp.IPAddress = IPAddress.Parse(header.Remove(header.IndexOf(':')));
            }
            else
            {
                clientIp.IPAddress = context.Request.HttpContext.Connection.RemoteIpAddress;
            }

            await _next.Invoke(context);
        }
    }
}
