
using MovieAPI.DTOs;

namespace MovieAPI.Helpers
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
