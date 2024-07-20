using System.Net;
using System.Text.Json.Serialization;
using ReservacionesApi.Common.Static;

namespace ReservacionesApi.Domain.Common;

public class ApiResult<T>
{
    [JsonInclude]
    internal T? Value { get; set; }

    [JsonInclude]
    internal ResponseMetadata Metadata { get; set; } = new ResponseMetadata();

    [JsonInclude]
    public List<string> Errors { get; set; } = [];

    protected ApiResult(T value)
    {
        Value = value;
    }

    protected ApiResult(HttpStatusCode statusCode)
    {
        Metadata = new ResponseMetadata(statusCode);
    }

    protected ApiResult(HttpStatusCode statusCode, string message)
    {
        Metadata = new ResponseMetadata(message, statusCode);
    }

    // protected internal ApiResult(T value, string successMessage)
    //     : this(value)
    // {
    //     SuccessMessage = successMessage;
    // }

    /// <summary>
    /// Representa una operación exitosa y acepta valores como resultado de la operación
    /// </summary>
    /// <param name="value">Establece la propiedad Value</param>
    /// <returns>Un ApiResult</returns>
    public static ApiResult<T> Succes(T value)
    {
        return new ApiResult<T>(HttpStatusCode.OK, ReplyMessage.Success.Query) { Value = value };
    }

    /// <summary>
    /// Represante una situación en donde un servicio no fue encontrado
    /// </summary>
    /// <returns>Un ApiResult</returns>
    public static ApiResult<T> NotFound()
    {
        return new ApiResult<T>(HttpStatusCode.NotFound, ReplyMessage.Error.QueryEmpty) { };
    }

    /// <summary>
    /// Representa un operacion exitosa que crea un nuevo valor
    /// </summary>
    /// <param name="value">El tipo de valor que se crea</param>
    /// <returns></returns>
    public static ApiResult<T> Created(T value)
    {
        return new ApiResult<T>(HttpStatusCode.OK, ReplyMessage.Success.Save) { Value = value };
    }

    public static ApiResult<T> Created()
    {
        return new ApiResult<T>(HttpStatusCode.OK, ReplyMessage.Success.Save);
    }

    public static ApiResult<T> Error(string errorMessage)
    {
        return new ApiResult<T>(HttpStatusCode.BadRequest, errorMessage) { Errors = [errorMessage] };
    }

    public static ApiResult<T> NoContent()
    {
        return new ApiResult<T>(HttpStatusCode.NoContent);
    }

    public static ApiResult<T> Validate(List<string> errorMessage)
    {
        return new ApiResult<T>(HttpStatusCode.BadRequest, ReplyMessage.Validate.ValidateError)
        {
            Errors = errorMessage
        };
    }
}

public class ResponseMetadata
{
    public HttpStatusCode StatusCode { get; set; }

    public string Message { get; set; } = string.Empty;

    public ResponseMetadata(string message, HttpStatusCode code)
    {
        Message = message;
        StatusCode = code;
    }

    public ResponseMetadata(string message)
    {
        Message = message;
    }

    public ResponseMetadata(HttpStatusCode code)
    {
        StatusCode = code;
    }

    public ResponseMetadata() { }
}
