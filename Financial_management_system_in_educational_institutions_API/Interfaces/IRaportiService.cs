using Financial_management_system_in_educational_institutions_API.Models.Dto;
using Financial_management_system_in_educational_institutions_API.Models.Shared;

namespace Financial_management_system_in_educational_institutions_API.Interfaces
{
    public interface IRaportiService
    {
        Task<Response<List<RaportetDto>>> GetAllRaportetAsync(
            string? kompania,
            string? shkolla,
            DateTime? ngaData,
            DateTime? deriData,
            List<string>? statuset
        );

        Task<Response<string>> GenerateRaportAsync(List<int> selectedIds, string emriRaportit, string pathRaportit);
    }
}
