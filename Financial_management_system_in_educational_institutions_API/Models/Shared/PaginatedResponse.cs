using System.Collections.Generic;

namespace Financial_management_system_in_educational_institutions_API.Models.Shared
{
    public class PaginatedResponse<T> : Response<List<T>>
    {
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / RecordsPerPage);

        public PaginatedResponse(List<T> data, int page, int recordsPerPage, int totalRecords, string message = null)
            : base(data, true, message)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            TotalRecords = totalRecords;
        }
    }
}
