using Adverts.Infrastructure.Interfaces;
using Adverts.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAdvertsRepository, AdvertsRepository>();
            services.AddTransient<IAdvertVisitRepository, AdvertVisitRepository>();
        }
    }
}
