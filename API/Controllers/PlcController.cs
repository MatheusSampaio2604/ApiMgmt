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

        [HttpGet("getValueFromPlc")]
        public async Task<IActionResult> GetValueFromPlc(string address)
        {
            try
            {
                var itens = await _interPlcService.ReadPlc(address);
                return Ok(itens);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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

        [HttpPost("SetValueToPlc")]
        public async Task<IActionResult> SetValueToPlc(List<RequestPlc> plc)
        {
            try
            {
                var itens = await _interPlcService.WritePlc(plc);
                return Ok(itens);
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
        public IActionResult UpdateSettingsPlc(PlcSettings plcSettings)
        {
            try
            {
                _interPlcService.UpdateSettingsPlc(plcSettings);
                return Ok(plcSettings);
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
