using Financial_management_system_in_educational_institutions_API.Models.Dto.Shporta;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IShportaService
    {
        Task<List<ShportaDto>> GetShportaByShkollaIdAsync(int shkollaId);
        Task AddToShportaAsync(int shkollaId, CreateShportaDto dto);
        Task UpdateShportaAsync(UpdateShportaDto dto);
        Task DeleteFromShportaAsync(int id);
    }
}
