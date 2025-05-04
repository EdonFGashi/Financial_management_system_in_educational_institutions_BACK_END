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


        public new PaginatedResponse<T> InternalServerError(string message = null)
        {
            base.InternalServerError(message);
            return this;
        }

        public new PaginatedResponse<T> NotFound(string message = null)
        {
            base.NotFound(message);
            return this;
        }

        public new PaginatedResponse<T> BadRequest(string message = null)
        {
            base.BadRequest(message);
            return this;
        }

        public new PaginatedResponse<T> UnAuthorized(string message = null)
        {
            base.UnAuthorized(message);
            return this;
        }
    }
}
