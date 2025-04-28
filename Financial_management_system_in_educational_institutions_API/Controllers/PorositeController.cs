using Microsoft.AspNetCore.Mvc;
using Financial_management_system_in_educational_institutions_API.Services.Interfaces;
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

        /// <summary>
        /// Gets the list of orders, with optional filters:
        /// pershkrimi (product name), kompania, shkolla, data (yyyy-MM-dd), status (“paguar”/“fshire”).
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PorositeDto>>> GetAll(
            [FromQuery] string? pershkrimi,
            [FromQuery] string? kompania,
            [FromQuery] string? shkolla,
            [FromQuery] DateTime? data,
            [FromQuery] string? status)
        {
            var list = await _porositeService.GetPorositeAsync(
                pershkrimi, kompania, shkolla, data, status);
            return Ok(list);
        }
    }
}
