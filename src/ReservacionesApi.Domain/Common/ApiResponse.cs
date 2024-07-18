using System.Net;

namespace ReservacionesApi.Domain.Common;

public class ApiResult<T>
{
    public T? Data { get; set; }

    public ResponseMetadata? Metadata { get; set; }

    public static ApiResult<T> Success(T data, string message, HttpStatusCode code)
    {
        return new ApiResult<T> { Data = data, Metadata = new ResponseMetadata(message, code) };
    }

    public static ApiResult<T> Error(string message, HttpStatusCode code)
    {
        return new ApiResult<T> { Metadata = new ResponseMetadata(message, code) };
    }
}

public class ResponseMetadata
{
    public HttpStatusCode StatusCode { get; set; }

    public string? Message { get; set; }

    public ResponseMetadata(string message, HttpStatusCode code)
    {
        Message = message;
        StatusCode = code;
    }
}
