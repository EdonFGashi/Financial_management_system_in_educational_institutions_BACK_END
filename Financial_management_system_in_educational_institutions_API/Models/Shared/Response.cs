using System.Net;
namespace Financial_management_system_in_educational_institutions_API.Models.Shared;

public class Response<T>
{
    public T Data { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public Response(T data, bool succeeded = true, string message = null, int statusCode = (int)HttpStatusCode.OK)
    {
        Data = data;
        Succeeded = succeeded;
        Message = message;
        StatusCode = statusCode;
    }

    private Response<T> SetErrorState(HttpStatusCode statusCode, string message)
    {
        Succeeded = false;
        Data = default;
        Message = message;
        StatusCode = (int)statusCode;
        return this;
    }

    public Response<T> InternalServerError(string message = null) =>
        SetErrorState(HttpStatusCode.InternalServerError, message);

    public Response<T> NotFound(string message = null) =>
        SetErrorState(HttpStatusCode.NotFound, message);

    public Response<T> BadRequest(string message = null) =>
        SetErrorState(HttpStatusCode.BadRequest, message);

    public Response<T> UnAuthorized(string message = null) =>
        SetErrorState(HttpStatusCode.Unauthorized, message);


    public Response<T> Ok(T data)
    {
        Succeeded = true;
        Data = data;
        StatusCode = (int)HttpStatusCode.OK;
        return this;
    }
}

