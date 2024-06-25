using Application.Services.Interfaces;
using Application.ViewModels.ApiPlc;
using Azure.Core;
using Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PlcService : InterPlcService
    {
        private readonly InterRequestApi _interRequestApi;

        readonly string routePlc = String.Concat(ApiRoutes.RouteLinkPLC, ApiRoutes.RoutePortPLC, ApiRoutes.RouteApiPLC);

        public PlcService(InterRequestApi interRequestApi)
        {
            _interRequestApi = interRequestApi;
        }

        public async Task<List<PlcConfig>> GetListPlcs()
        {
            var item = await _interRequestApi.GetAsync<List<PlcConfig>>($"{routePlc}/Plc/GetListPlc");
            return item;

        }
        public async Task<RequestPlc> ReadPlc(string address)
        {
            var item = await _interRequestApi.GetAsync<RequestPlc>($"{routePlc}/Plc/read/{address}");
            return item;

        }

        public async Task<bool> WritePlc(List<RequestPlc> requestPlc)
        {

            foreach (var request in requestPlc)
            {
                await _interRequestApi.PostAsync<RequestPlc, dynamic>($"{routePlc}/Plc/write", request);
            }
            return true;
        }

        public async Task<PlcSettings> GetSettingsPlc()
        {
            var item = await _interRequestApi.GetAsync<PlcSettings>($"{routePlc}/Plc/GetSettingsPlc");
            return item;
        }

        public void UpdateSettingsPlc(PlcSettings settings)
        {
            _interRequestApi.PostAsync<PlcSettings, dynamic>($"{routePlc}/Plc/write", settings);
        }

        public async Task<bool> TestConnectionPlc()
        {
            return await _interRequestApi.GetAsync<bool>($"{routePlc}/Plc/TestConnectionPlc");
        }

    }
}
