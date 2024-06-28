using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface InterCameraService
    {
        Task<vmCalibrationCamera> GetCalibrationCameraAsync();
        Task<bool> SetCalibrationCameraAsync(vmCalibrationCamera calibrationCamera);
    }
}
