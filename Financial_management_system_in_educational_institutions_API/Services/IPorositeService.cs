using Financial_management_system_in_educational_institutions_API.Models.Dto;

namespace Financial_management_system_in_educational_institutions_API.Services.Interfaces
{
    public interface IPorositeService
    {
        Task<IEnumerable<PorositeDto>> GetPorositeAsync(
            string? pershkrimi,
            string? kompania,
            string? shkolla,
            DateTime? data,
            string? status);

        Task<bool> PaguajPorosiAsync(int id);
        Task<bool> FshijPorosiAsync(int id);
    }
}