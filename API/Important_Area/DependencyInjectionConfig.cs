using Application.Services;
using Application.Services.Interfaces;
using Infra.Repository;
using Infra.Repository.Interfaces;

namespace API.Important_Area
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<InterRequestApi, GeneralRequestApi>();

            services.AddScoped<InterPlcService, PlcService>();
            services.AddScoped<InterCameraService, CameraService>();
            services.AddTransient<InterEmailService, GeneralEmailService>();

            return services;
        }
    }
}