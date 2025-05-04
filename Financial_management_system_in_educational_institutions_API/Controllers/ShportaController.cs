using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shporta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Financial_management_system_in_educational_institutions_API.Controllers
{
    [Authorize(Roles = "Shkolla")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShportaController : ControllerBase
    {
        private readonly IShportaService _shportaService;

        public ShportaController(IShportaService shportaService)
        {
            _shportaService = shportaService;
        }

        [HttpGet("{shkollaId}")]
        public async Task<ActionResult> GetShporta(int shkollaId)
        {
            var items = await _shportaService.GetShportaByShkollaIdAsync(shkollaId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> AddToShporta(CreateShportaDto dto)
        {
            await _shportaService.AddToShportaAsync(dto.ShkollaId, dto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateShporta(UpdateShportaDto dto)
        {
            await _shportaService.UpdateShportaAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFromShporta(int id)
        {
            await _shportaService.DeleteFromShportaAsync(id);
            return Ok();
        }
    }
}
