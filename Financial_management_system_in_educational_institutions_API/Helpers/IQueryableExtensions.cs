
using Financial_management_system_in_educational_institutions_API.DTOs;

namespace Financial_management_system_in_educational_institutions_API.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
        {

            return queryable
                .Skip((paginationDTO.Page - 1) * paginationDTO.RecordsPerPage) //skip do te skipoje numrin e rekordeve qe jane para faqes se pare
                .Take(paginationDTO.RecordsPerPage); //take do te marre numrin e rekordeve qe jane ne faqen e pare
        }
    }
}
