using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Interfaces;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/{schemaName}/[controller]")]
public class StafiShkollesController : ControllerBase
{
    private readonly IStafiService _service;

    public StafiShkollesController(IStafiService service)
    {
        _service = service;
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginated([FromRoute] string schemaName, [FromQuery] PaginationDTO paginationDto)
    {
        var result = await _service.GetAllPaginatedAsync(schemaName, paginationDto);
        return StatusCode(result.StatusCode, result);
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
    public async Task<IActionResult> Create([FromRoute] string schemaName, [FromBody] CreateStafiShkollesDto dto)
    {
        var result = await _service.CreateAsync(schemaName, dto);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] string schemaName, int id, [FromBody] UpdateStafiShkollesDto dto)
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
