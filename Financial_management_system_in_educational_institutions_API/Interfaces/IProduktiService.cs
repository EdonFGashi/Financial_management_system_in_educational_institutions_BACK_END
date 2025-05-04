using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto.Produkti;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IProduktiService
    {

        Task<Response<List<Produkti>>> GetAllAsync();
        Task<Response<Produkti>> GetByIdAsync(int id);
        Task<Response<Produkti>> CreateAsync(CreateProduktiDto produktiDto);
        Task<Response<Produkti>> UpdateAsync(UpdateProduktiDto produktiDto);
        Task<Response<string>> DeleteAsync(int id);

    }
}
