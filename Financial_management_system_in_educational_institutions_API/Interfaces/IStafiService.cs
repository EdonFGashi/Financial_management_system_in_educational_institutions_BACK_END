using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IStafiService
    {
        Task<PaginatedResponse<StafiShkollesDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto);
        Task<Response<StafiShkollesDto>> GetByIdAsync(string schemaName, int id);
        Task<Response<bool>> CreateAsync(string schemaName, CreateStafiShkollesDto dto);
        Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateStafiShkollesDto dto);
        Task<Response<bool>> DeleteAsync(string schemaName, int id);
    }
}
