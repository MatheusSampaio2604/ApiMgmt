﻿using Infra.Context;
using Infra.Repository.Interfaces;
using Infra.Repository;
using Microsoft.AspNetCore.Identity;
using Application.Services;
using Application.Services.Interfaces;

namespace API.Important_Area
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();

            services.AddTransient<InterEmailService, GeneralEmailService>();

            services.AddHttpClient<InterRequestApi, GeneralRequestApi>();

            services.AddSingleton(typeof(InterRepository<>), typeof(GeneralRepository<>));
            
            
            //services.AddScoped<Interface_Repo_Compra, Repository_Compra>();

            //services.AddScoped<Interface_Application_Compra, Application_Compra>();

            //******************************************************************* Asp.Net Identity*******************************************************************
            //   services.AddScoped<IIdentityService, IdentityService>();

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<DataContext>()
            //    .AddDefaultTokenProviders();


            //*******************************************************************Asp.Net Identity*******************************************************************

            return services;
        }
    }
}