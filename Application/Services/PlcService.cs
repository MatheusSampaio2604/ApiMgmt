using Application.Services.Interfaces;
using Application.ViewModels.ApiPlc;
using Infra.Repository.Interfaces;

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
        public async Task<string> ReadPlc(string address)
        {
            object? item = await _interRequestApi.GetAsync<object>($"{routePlc}/Plc/read/{address}");

            return item.ToString();

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

        public async Task<bool> AddTagInList(List<PlcConfig> plc)
        {
            return await _interRequestApi.PostAsync<List<PlcConfig>, bool>($"{routePlc}/plc/SaveInListPlc", plc);
        }

        public async Task<bool> UpdateTagInList(PlcConfig plc)
        {
            return await _interRequestApi.PutAsync<PlcConfig, bool>($"{routePlc}/plc/{plc.Id}/updateTag", plc);
        }

        public async Task<bool> DeleteTagInList(int id)
        {
            return await _interRequestApi.DeleteAsync<int, bool>($"{routePlc}/plc/{id}/deleteTagList");
        }
    }
}
