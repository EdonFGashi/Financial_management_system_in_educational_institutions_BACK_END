using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IProduktiService
    {
      
            Task<Response<List<Produkti>>> GetAllAsync();
            Task<Response<Produkti>> GetByIdAsync(int id);
            Task<Response<Produkti>> CreateAsync(ProduktiDto produktiDto);
            Task<Response<Produkti>> UpdateAsync(int id, ProduktiDto produktiDto);
            Task<Response<string>> DeleteAsync(int id);
        
    }
}
