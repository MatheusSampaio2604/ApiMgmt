using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

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
