using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adverts.Core.Mapping
{
    public static class IServiceCollectionExtension
    {
        public static IConfiguration _configuration { get; set; }

        public static void RegisterMappingProfiles(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AdvertsMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            services.AddSingleton<IMappingBase, MappingBase>();

            mappingConfig.CompileMappings();
        }
    }
}
