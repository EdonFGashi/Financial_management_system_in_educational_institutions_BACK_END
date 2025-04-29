using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IPorositeService
    {
        Task<Response<List<PorositeDto>>> GetPorositeAsync(
            string? pershkrimi,
            string? kompania,
            string? shkolla,
            DateTime? data,
            string? status);

        Task<Response<string>> PaguajPorosiAsync(int id);
        Task<Response<string>> FshijPorosiAsync(int id);
    }
}
