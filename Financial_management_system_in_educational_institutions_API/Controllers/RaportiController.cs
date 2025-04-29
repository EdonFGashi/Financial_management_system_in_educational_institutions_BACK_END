using Microsoft.AspNetCore.Mvc;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaportiController : ControllerBase
    {
        private readonly IRaportiService _raportiService;

        public RaportiController(IRaportiService raportiService)
        {
            _raportiService = raportiService;
        }

        /// <summary>
        /// Merr të gjitha raportet me mundësi filtrimi
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Response<List<RaportetDto>>), 200)]
        public async Task<IActionResult> GetAllRaportet(
            [FromQuery] string? kompania,
            [FromQuery] string? shkolla,
            [FromQuery] DateTime? ngaData,
            [FromQuery] DateTime? deriData,
            [FromQuery] List<string>? statuset

        )
        {
            var result = await _raportiService.GetAllRaportetAsync(kompania, shkolla, ngaData, deriData, statuset);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Gjeneron një raport në bazë të përzgjedhjeve
        /// </summary>
        [HttpPost("gjenero")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [ProducesResponseType(typeof(Response<string>), 400)]
        public async Task<IActionResult> GenerateRaport([FromBody] GenerateRaportRequest request)
        {
            if (request == null || request.SelectedIds == null || !request.SelectedIds.Any())
            {
                return BadRequest(new Response<string>(null).BadRequest("Asnjë porosi nuk është përzgjedhur për gjenerim."));
            }

            var result = await _raportiService.GenerateRaportAsync(request.SelectedIds, request.EmriRaportit, request.PathRaportit);
            return StatusCode(result.StatusCode, result);
        }
    }

    /// <summary>
    /// DTO për kërkesën e gjenerimit të raportit
    /// </summary>
    public class GenerateRaportRequest
    {
        public List<int> SelectedIds { get; set; } = new();
        public string EmriRaportit { get; set; } = string.Empty;
        public string PathRaportit { get; set; } = string.Empty;
    }
}
