using Application.Services.Interfaces;
using Application.ViewModels.ApiPlc;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlcController : ControllerBase
    {
        private readonly InterPlcService _interPlcService;

        public PlcController(InterPlcService interPlcService)
        {
            _interPlcService = interPlcService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpGet("getValueFromPlc/{address}")]
        public async Task<IActionResult> GetValueFromPlc(string address)
        {
            try
            {
                var itens = await _interPlcService.ReadPlc(address);
                return Ok(itens.Replace(",", "."));
            }
            catch (Exception e)
            {
                return Ok("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plc"></param>
        /// <returns></returns>
        [HttpPost("SetValueToPlc")]
        public async Task<IActionResult> SetValueToPlc(List<RequestPlc> plc)
        {
            try
            {
                return Ok(await _interPlcService.WritePlc(plc));
            }
            catch
            {
                return Ok(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getListPlc")]
        public async Task<IActionResult> GetListPlc()
        {
            try
            {
                return Ok(await _interPlcService.GetListPlcs());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plc"></param>
        /// <returns></returns>
        [HttpPost("AddTagInList")]
        public async Task<IActionResult> AddTagInList(List<PlcConfig> plc)
        {
            try
            {
                return Ok(await _interPlcService.AddTagInList(plc));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plc"></param>
        /// <returns></returns>
        [HttpPost("UpdateTagInList")]
        public async Task<IActionResult> UpdateTagInList(PlcConfig plc)
        {
            try
            {
                return Ok(_interPlcService.UpdateTagInList(plc));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}/DeleteTagInList")]
        public async Task<IActionResult> DeleteTagInList(int id)
        {
            try
            {
                return Ok(await _interPlcService.DeleteTagInList(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSettingsPlc")]
        public async Task<IActionResult> GetSettingsPlc()
        {
            try
            {
                return Ok(await _interPlcService.GetSettingsPlc());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plcSettings"></param>
        /// <returns></returns>
        [HttpPost("UpdateSettingsPlc")]
        public async Task<IActionResult> UpdateSettingsPlc(PlcSettings plcSettings)
        {
            try
            {
                return Ok(await _interPlcService.UpdateSettingsPlc(plcSettings));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Test Connection
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestConnectionPlc")]
        public async Task<IActionResult> TestConnectionPlc()
        {
            try
            {
                return Ok(await _interPlcService.TestConnectionPlc());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
