using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IStafiService
    {
        Task<PaginatedResponse<StafiShkolles>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto);
        Task<Response<List<StafiShkolles>>> GetAllAsync(string schemaName);
        Task<Response<StafiShkolles>> GetByIdAsync(string schemaName, int id);
        Task<Response<StafiShkolles>> CreateAsync(string schemaName, CreateStafiShkollesDto dto);
        Task<Response<StafiShkolles>> UpdateAsync(string schemaName, int id, UpdateStafiShkollesDto dto);
        Task<Response<string>> DeleteAsync(string schemaName, int id);
    }
}
