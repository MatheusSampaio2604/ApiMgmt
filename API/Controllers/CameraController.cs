using Application.Services.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly InterCameraService _interCameraService;

        public CameraController(InterCameraService interCameraService)
        {
            _interCameraService = interCameraService;
        }


        // GET: CameraController
        [HttpGet("GetCalibrationCameraAsync")]
        public async Task<IActionResult> GetCalibrationCameraAsync()
        {
            try
            {
                return Ok(await _interCameraService.GetCalibrationCameraAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: CameraController/Create
        [HttpPost("SetCalibrationCameraAsync")]
        public async Task<IActionResult> SetCalibrationCameraAsync(vmCalibrationCamera calibrationCamera)
        {
            try
            {
                return Ok(await _interCameraService.SetCalibrationCameraAsync(calibrationCamera));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
