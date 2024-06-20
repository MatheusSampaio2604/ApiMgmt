using API.Important_Area;
using Application.ViewModels.ApiPlc;
using Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcController : ControllerBase
    {
        private readonly InterRequestApi _interRequestApi;
        ApiRoutes routes = new ApiRoutes();

        public PlcController(InterRequestApi interRequestApi)
        {
            _interRequestApi = interRequestApi;
        }

        [HttpGet("getValueFromPlc")]
        public async Task<IActionResult> GetValueFromPlc(string address)
        {
            var itens = await _interRequestApi.GetAsync<RequestPlc>($"{routes.RouteLinkPLC + routes.RoutePortPLC}/Plc/read/{address}");
            return Ok(itens);
        }

        [HttpGet("getListPlc")]
        public async Task<IActionResult> GetListPlc()
        {
            var itens = await _interRequestApi.GetAsync<RequestPlc>($"{routes.RouteLinkPLC + routes.RoutePortPLC}/Plc/GetListPlc");
            return Ok(itens);
        }

        
    }
}
