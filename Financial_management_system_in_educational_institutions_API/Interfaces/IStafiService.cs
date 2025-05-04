using Financial_management_system_in_educational_institutions_API.DTOs;
using Financial_management_system_in_educational_institutions_API.Models.Shared;
using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla.Stafi;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IStafiService
    {
        Task<PaginatedResponse<StafiShkolles>> GetAllPaginatedAsync(PaginationDTO paginationDto);
        Task<Response<List<StafiShkolles>>> GetAllAsync();
        Task<Response<StafiShkolles>> GetByIdAsync(int id);
        Task<Response<StafiShkolles>> CreateAsync(CreateStafiShkollesDto dto);
        Task<Response<StafiShkolles>> UpdateAsync(int id, UpdateStafiShkollesDto dto);
        Task<Response<string>> DeleteAsync(int id);

    }
}
