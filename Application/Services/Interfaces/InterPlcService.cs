using Application.ViewModels.ApiPlc;

namespace Application.Services.Interfaces
{
    public interface InterPlcService
    {
        Task<List<PlcConfig>> GetListPlcs();
        Task<bool> AddTagInList(List<PlcConfig> plc);
        Task<bool> UpdateTagInList(PlcConfig plc);
        Task<bool> DeleteTagInList(int id);

        Task<string> ReadPlc(string address);
        Task<bool> WritePlc(List<RequestPlc> requestPlc);

        Task<PlcSettings> GetSettingsPlc();
        Task<bool> UpdateSettingsPlc(PlcSettings settings);

        Task<bool> TestConnectionPlc();
    }
}
