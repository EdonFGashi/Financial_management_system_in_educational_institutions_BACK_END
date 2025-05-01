using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Kompania;
using Financial_management_system_in_educational_institutions_API.Models.Shared;


namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IKompaniaService
    {
        Task<Response<List<Kompania>>> GetAllAsync();
        Task<Response<Kompania>> GetByIdAsync(int id);
        Task<Response<Kompania>> CreateAsync(KompaniaDto Kompania);
        Task<Response<Kompania>> UpdateAsync(int id, UpdateKompaniaDto updatedKompania);
        Task<Response<string>> DeleteAsync(int id);

    }
}
