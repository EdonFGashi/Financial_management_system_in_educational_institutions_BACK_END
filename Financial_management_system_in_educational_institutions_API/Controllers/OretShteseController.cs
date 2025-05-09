using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi.OretShtese;
using Microsoft.AspNetCore.Mvc;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [ApiController]
    [Route("api/{schemaName}/[controller]")]
    public class OretShteseController : ControllerBase
    {
        private readonly IOretShteseService _service;

        public OretShteseController(IOretShteseService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string schemaName, int id)
        {
            var result = await _service.GetByIdAsync(schemaName, id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] string schemaName, [FromBody] CreateOretShteseDto dto)
        {
            var result = await _service.CreateAsync(schemaName, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string schemaName, int id, [FromBody] UpdateOretShteseDto dto)
        {
            var result = await _service.UpdateAsync(schemaName, id, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string schemaName, int id)
        {
            var result = await _service.DeleteAsync(schemaName, id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
