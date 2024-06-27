﻿using Application.Services.Interfaces;
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
            return await _interRequestApi.PostAsync<List<RequestPlc>, bool>($"{routePlc}/Plc/write", requestPlc); ;
        }

        public async Task<PlcSettings> GetSettingsPlc()
        {
            var item = await _interRequestApi.GetAsync<PlcSettings>($"{routePlc}/Plc/GetSettingsPlc");
            return item;
        }

        public async Task<bool> UpdateSettingsPlc(PlcSettings settings)
        {
            return await _interRequestApi.PostAsync<PlcSettings, bool>($"{routePlc}/Plc/UpdateSettingsPlc", settings);
        }

        public async Task<bool> TestConnectionPlc()
        {
            return await _interRequestApi.GetAsync<bool>($"{routePlc}/Plc/TestConnectionPlc");
        }

        public async Task<bool> AddTagInList(PlcConfig plc)
        {
            return await _interRequestApi.PostAsync<PlcConfig, bool>($"{routePlc}/plc/SaveInListPlc", plc);
        }

        public async Task<bool> UpdateTagInList(PlcConfig plc)
        {
            return await _interRequestApi.PutAsync<PlcConfig, bool>($"{routePlc}/plc/{plc.Id}/updateTag", plc);
        }
    }
}
