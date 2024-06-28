using Application.ViewModels;

namespace Application.Services.Interfaces
{
    public interface InterCameraService
    {
        Task<vmCalibrationCamera> GetCalibrationCameraAsync();
        Task<bool> SetCalibrationCameraAsync(vmCalibrationCamera calibrationCamera);
    }
}
