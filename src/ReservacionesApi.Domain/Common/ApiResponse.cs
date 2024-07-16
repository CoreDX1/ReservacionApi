namespace ReservacionesApi.Domain.Common;

public class ApiResult<T>
{
    public T? Data { get; set; }

    public ResponseMetadata? Metadata { get; set; }

    public static ApiResult<T> Success(T data, string message, int code)
    {
        return new ApiResult<T> { Data = data, Metadata = new ResponseMetadata(message, code) };
    }

    public static ApiResult<T> Error(string message, int code)
    {
        return new ApiResult<T> { Metadata = new ResponseMetadata(message, code) };
    }
}

public class ResponseMetadata
{
    public int StatusCode { get; set; }

    public string? Message { get; set; }

    public ResponseMetadata(string message, int code)
    {
        Message = message;
        StatusCode = code;
    }
}
