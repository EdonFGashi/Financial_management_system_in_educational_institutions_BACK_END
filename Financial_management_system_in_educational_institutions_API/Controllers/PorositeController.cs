using Microsoft.AspNetCore.Mvc;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models.Dto;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PorositeController : ControllerBase
    {
        private readonly IPorositeService _porositeService;

        public PorositeController(IPorositeService porositeService)
        {
            _porositeService = porositeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<List<PorositeDto>>), 200)]
        public async Task<IActionResult> GetPorosite(
            [FromQuery] string? pershkrimi,
            [FromQuery] string? kompania,
            [FromQuery] string? shkolla,
            [FromQuery] DateTime? data,
            [FromQuery] string? status)
        {
            var result = await _porositeService.GetPorositeAsync(pershkrimi, kompania, shkolla, data, status);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("paguaj/{id}")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public async Task<IActionResult> Paguaj(int id)
        {
            var result = await _porositeService.PaguajPorosiAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("fshij/{id}")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public async Task<IActionResult> Fshij(int id)
        {
            var result = await _porositeService.FshijPorosiAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
