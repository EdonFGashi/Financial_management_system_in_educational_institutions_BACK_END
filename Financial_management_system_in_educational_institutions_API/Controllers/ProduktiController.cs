using Microsoft.AspNetCore.Mvc;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Produkti;

namespace Financial_management_system_in_educational_institutions_API.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class ProduktiController : ControllerBase
        {
            private readonly IProduktiService _produktiService;

            public ProduktiController(IProduktiService produktiService)
            {
                _produktiService = produktiService;
            }

            // GET: api/produkti
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var response = await _produktiService.GetAllAsync();
                return StatusCode(response.StatusCode, response);
            }

            // GET: api/produkti/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var response = await _produktiService.GetByIdAsync(id);
                return StatusCode(response.StatusCode, response);
            }

            // POST: api/produkti
            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateProduktiDto produktiDto)
            {
                var response = await _produktiService.CreateAsync(produktiDto);
                return StatusCode(response.StatusCode, response);
            }

            // PUT: api/produkti/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Update([FromBody] UpdateProduktiDto produktiDto)
            {
                var response = await _produktiService.UpdateAsync(produktiDto);
                return StatusCode(response.StatusCode, response);
            }

            // DELETE: api/produkti/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var response = await _produktiService.DeleteAsync(id);
                return StatusCode(response.StatusCode, response);
            }
        }
    }

