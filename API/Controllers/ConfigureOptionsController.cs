using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class ConfigureOptionsController : ControllerBase
    {
        private readonly InterConfigureOptionsServices _configureOptionsServices;

        public ConfigureOptionsController(InterConfigureOptionsServices configureOptionsServices)
        {
            _configureOptionsServices = configureOptionsServices;
        }

        [HttpGet("GetDriversOptions")]
        public async Task<IActionResult> GetDriversOptions()
        {
            try
            {
                return Ok(await _configureOptionsServices.GetDriversOptions());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetCpuTypesOptions")]
        public async Task<IActionResult> GetCpuTypesOptions()
        {
            try
            {
                return Ok(await _configureOptionsServices.GetCpuTypesOptions());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
