using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Shkolla;
using Financial_management_system_in_educational_institutions_API.Models.Shared;


namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IShkollaService
    {
        Task<Response<List<Shkolla>>> GetAllAsync(string schemaName);
        Task<Response<Shkolla>> GetByIdAsync(string schemaName, int id);
        Task<Response<Shkolla>> CreateAsync(string schemaName, ShkollaDto shkolla);
        Task<Response<Shkolla>> UpdateAsync(string schemaName, int id, UpdateShkollaDto updatedShkolla);
        Task<Response<string>> DeleteAsync(string schemaName, int id);

    }
}
