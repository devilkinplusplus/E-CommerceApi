using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
