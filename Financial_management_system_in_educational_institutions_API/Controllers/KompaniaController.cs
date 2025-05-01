using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Kompania;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KompaniaController : ControllerBase
    {
        private readonly IKompaniaService _kompaniaService ;

        public KompaniaController(IKompaniaService kompaniaService)
        {
            _kompaniaService = kompaniaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<List<Kompania>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _kompaniaService.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<Kompania>), 200)]
        [ProducesResponseType(typeof(Response<Kompania>), 404)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _kompaniaService.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<Kompania>), 200)]
        [ProducesResponseType(typeof(Response<Kompania>), 400)]
        public async Task<IActionResult> Create([FromBody] KompaniaDto kompaniaDto)
        {
            var result = await _kompaniaService.CreateAsync(kompaniaDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<Kompania>), 200)]
        [ProducesResponseType(typeof(Response<Kompania>), 404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateKompaniaDto updateKompania)
        {
            var result = await _kompaniaService.UpdateAsync(id, updateKompania);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [ProducesResponseType(typeof(Response<string>), 404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _kompaniaService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
