using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;
using Financial_management_system_in_educational_institutions_API.Models.Shared;


namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IShkollaService
    {
        Task<Response<List<Shkolla>>> GetAllAsync();
        Task<Response<Shkolla>> GetByIdAsync(int id);
        Task<Response<Shkolla>> CreateAsync(ShkollaDto shkolla);
        Task<Response<Shkolla>> UpdateAsync(int id, UpdateShkollaDto updatedShkolla);
        Task<Response<string>> DeleteAsync(int id);

    }
}
