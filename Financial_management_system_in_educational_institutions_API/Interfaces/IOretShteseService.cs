using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi.OretShtese;
using Financial_management_system_in_educational_institutions_API.Models.Shared;


namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IOretShteseService
    {
        Task<Response<bool>> CreateAsync(string schemaName, CreateOretShteseDto dto);
        Task<Response<bool>> DeleteAsync(string schemaName, int id);
        Task<Response<OretShteseDto>> GetByIdAsync(string schemaName, int id);
        Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateOretShteseDto dto);
        Task<PaginatedResponse<OretShteseDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto);
    }
}
