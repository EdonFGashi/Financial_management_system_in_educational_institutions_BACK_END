using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi.Ndalesat;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface INdalesatService
    {
        Task<PaginatedResponse<NdalesatDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto);
        Task<Response<NdalesatDto>> GetByIdAsync(string schemaName, int id);
        Task<Response<bool>> CreateAsync(string schemaName, CreateNdalesatDto dto);
        Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateNdalesatDto dto);
        Task<Response<bool>> DeleteAsync(string schemaName, int id);
    }
}
