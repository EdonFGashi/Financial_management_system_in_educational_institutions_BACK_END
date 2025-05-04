using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShkollaController : ControllerBase
    {
        private readonly IShkollaService _shkollaService;

        public ShkollaController(IShkollaService shkollaService)
        {
            _shkollaService = shkollaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Response<List<Shkolla>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _shkollaService.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<Shkolla>), 200)]
        [ProducesResponseType(typeof(Response<Shkolla>), 404)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _shkollaService.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response<Shkolla>), 200)]
        [ProducesResponseType(typeof(Response<Shkolla>), 400)]
        public async Task<IActionResult> Create([FromBody] ShkollaDto shkollaDto)
        {
            var result = await _shkollaService.CreateAsync(shkollaDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<Shkolla>), 200)]
        [ProducesResponseType(typeof(Response<Shkolla>), 404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShkollaDto updatedShkolla)
        {
            var result = await _shkollaService.UpdateAsync(id, updatedShkolla);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        [ProducesResponseType(typeof(Response<string>), 404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _shkollaService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
