using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperAll.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            MapperConfiguration autoMapperConfig = new(x => { x.AddProfile(new AutoMapperProfile()); });
            IMapper mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
