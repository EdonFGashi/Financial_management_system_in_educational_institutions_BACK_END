using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Inventari;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IInventariAktualService
    {
        Task<PaginatedResponse<InventariAktualDto>> GetAllPaginatedAsync(string schemaName, PaginationDTO paginationDto);
        Task<Response<bool>> CreateAsync(string schemaName, CreateInventariAktualDto dto);
        Task<Response<bool>> UpdateAsync(string schemaName, int id, UpdateInventariAktualDto dto);
        Task<Response<bool>> DeleteAsync(string schemaName, int id);
        Task<Response<InventariAktualDto>> GetByIdAsync(string schemaName, int id);

    }
}
