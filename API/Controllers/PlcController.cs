using API.Important_Area;
using Application.Services.Interfaces;
using Application.ViewModels.ApiPlc;
using Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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

        [HttpGet("getValueFromPlc/{address}")]
        public async Task<IActionResult> GetValueFromPlc(string address)
        {
            try
            {
                var itens = await _interPlcService.ReadPlc(address);
                return Ok(itens);
            }
            catch (Exception e)
            {
                return Ok(new RequestPlc());
            }
        }

        [HttpPost("SetValueToPlc")]
        public async Task<IActionResult> SetValueToPlc(List<RequestPlc> plc)
        {
            try
            {
                var itens = await _interPlcService.WritePlc(plc);
                return Ok(itens);
            }
            catch
            {
                return Ok(false);
            }
        }

        [HttpGet("getListPlc")]
        public async Task<IActionResult> GetListPlc()
        {
            try
            {
                var itens = await _interPlcService.GetListPlcs();
                return Ok(itens);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddTagInList")]
        public async Task<IActionResult> AddTagInList(List<PlcConfig> plc)
        {
            try
            {
                var resp = await _interPlcService.AddTagInList(plc);
                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("UpdateTagInList")]
        public async Task<IActionResult> UpdateTagInList(PlcConfig plc)
        {
            try
            {
                var resp = await _interPlcService.UpdateTagInList(plc);
                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}/DeleteTagInList")]
        public async Task<IActionResult> DeleteTagInList(int id)
        {
            try
            {
                var resp = await _interPlcService.DeleteTagInList(id);
                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("GetSettingsPlc")]
        public async Task<IActionResult> GetSettingsPlc()
        {
            try
            {
                PlcSettings settings = await _interPlcService.GetSettingsPlc();
                return Ok(settings);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("UpdateSettingsPlc")]
        public async Task<IActionResult> UpdateSettingsPlc(PlcSettings plcSettings)
        {
            try
            {
                bool resp = await _interPlcService.UpdateSettingsPlc(plcSettings);

                return Ok(resp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("TestConnectionPlc")]
        public async Task<IActionResult> TestConnectionPlc()
        {
            try
            {
                bool settings = await _interPlcService.TestConnectionPlc();
                return Ok(settings);
            }
            catch
            {
                return Ok(false);
            }
        }
    }
}
