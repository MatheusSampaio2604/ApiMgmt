using Application.Services.Interfaces;
using Application.ViewModels;
using Infra.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CameraService : InterCameraService
    {
        private readonly InterRequestApi _interRequestApi;

        public CameraService(InterRequestApi interRequestApi)
        {
            _interRequestApi = interRequestApi;
        }


        static vmCalibrationCamera? vmCC;


        public async Task<vmCalibrationCamera> GetCalibrationCameraAsync()
        {
            //var dataRequest = await _interRequestApi.GetAsync<vmCalibrationCamera>($"");


            return vmCC;
        }

        public async Task<bool> SetCalibrationCameraAsync(vmCalibrationCamera calibrationCamera)
        {
            //var dataRequest = await _interRequestApi.PostAsync<vmCalibrationCamera, bool>("", calibrationCamera);
            vmCC = calibrationCamera;

            return true;
        }
    }
}
