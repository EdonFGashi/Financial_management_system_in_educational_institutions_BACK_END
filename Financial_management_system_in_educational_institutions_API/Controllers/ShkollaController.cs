using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/{schemaName}/[controller]")]
public class ShkollaController : ControllerBase
{
    private readonly IShkollaService _service;

    public ShkollaController(IShkollaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromRoute] string schemaName)
    {
        var result = await _service.GetAllAsync(schemaName);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string schemaName, int id)
    {
        var result = await _service.GetByIdAsync(schemaName, id);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromRoute] string schemaName, [FromBody] ShkollaDto dto)
    {
        var result = await _service.CreateAsync(schemaName, dto);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] string schemaName, int id, [FromBody] UpdateShkollaDto dto)
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
