using Application.Services.Interfaces;
using Application.ViewModels.ApiPlc;
using Domain.Models;
using Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ConfigureOptionsService : InterConfigureOptionsServices
    {

        readonly string routePlc = String.Concat(ApiRoutes.RouteLinkPLC, ApiRoutes.RoutePortPLC, ApiRoutes.RouteApiPLC);
        
        private readonly InterRequestApi _requestApi;

        public ConfigureOptionsService(InterRequestApi requestApi)
        {
            _requestApi = requestApi;
        }

        public async Task<List<Drivers>> GetDriversOptions()
        {
            return await _requestApi.GetAsync<List<Drivers>>($"{routePlc}/ConfigureOptions/GetDriversOptions");
        }

        public async Task<List<CpuTypes>> GetCpuTypesOptions()
        {
            return await _requestApi.GetAsync<List<CpuTypes>>($"{routePlc}/ConfigureOptions/GetCpuTypesOptions");
        }
    }
}
