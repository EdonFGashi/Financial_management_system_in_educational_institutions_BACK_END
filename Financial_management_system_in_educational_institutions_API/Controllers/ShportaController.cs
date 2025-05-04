using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shporta;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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

        [HttpGet]
        public async Task<ActionResult> GetShporta()
        {
            int shkollaId = JwtHelper.GetUserId(HttpContext.User);
            var items = await _shportaService.GetShportaByShkollaIdAsync(shkollaId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> AddToShporta(CreateShportaDto dto)
        {
            int shkollaId = JwtHelper.GetUserId(HttpContext.User);
            await _shportaService.AddToShportaAsync(shkollaId, dto);
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
