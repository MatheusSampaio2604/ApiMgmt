using Application.ViewModels;
using Application.ViewModels.ApiPlc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface InterPlcService
    {
        Task<List<PlcConfig>> GetListPlcs();
        Task<RequestPlc> ReadPlc(string address);
        Task<bool> WritePlc(List<RequestPlc> requestPlc);

        Task<PlcSettings> GetSettingsPlc();
        void UpdateSettingsPlc(PlcSettings settings);

        Task<bool> TestConnectionPlc();
    }
}
