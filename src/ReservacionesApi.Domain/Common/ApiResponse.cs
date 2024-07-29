using System.Net;
using System.Text.Json.Serialization;
using ReservacionesApi.Common.Static;

namespace ReservacionesApi.Domain.Common;

public class ApiResult<T>
{
    [JsonInclude]
    internal T? Data { get; private set; }

    [JsonInclude]
    internal ResponseMetadata Metadata { get; private set; } = new ResponseMetadata();

    [JsonInclude]
    public List<string>? Errors { get; private set; }

    public UserLoginErrors LoginErrors { get; private set; } = new UserLoginErrors();

    protected ApiResult(T data)
    {
        Data = data;
    }

    protected ApiResult(HttpStatusCode statusCode)
    {
        Metadata = new ResponseMetadata(statusCode);
    }

    protected ApiResult(HttpStatusCode statusCode, string message)
    {
        Metadata = new ResponseMetadata(message, statusCode);
    }

    /// <summary>
    /// Representa una operación exitosa y acepta valores como resultado de la operación
    /// </summary>
    /// <param name="data">Establece la propiedad Value</param>
    /// <returns>Un ApiResult</returns>
    public static ApiResult<T> Succes(T data)
    {
        return new ApiResult<T>(HttpStatusCode.OK, ReplyMessage.Success.Query) { Data = data };
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
    /// <param name="data">El tipo de valor que se crea</param>
    /// <returns></returns>
    public static ApiResult<T> Created(T data)
    {
        return new ApiResult<T>(HttpStatusCode.OK, ReplyMessage.Success.Save) { Data = data };
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

    public static ApiResult<T> Validate(UserLoginErrors errorMessage)
    {
        return new ApiResult<T>(HttpStatusCode.Unauthorized, ReplyMessage.Validate.ValidateError)
        {
            LoginErrors = errorMessage
        };
    }

    public static ApiResult<T> Login(T data)
    {
        return new ApiResult<T>(HttpStatusCode.OK, ReplyMessage.Info.Login) { Data = data };
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

public class UserLoginErrors
{
    public List<string> EmailErorrs { get; set; } = [];
    public List<string> PasswordErorrs { get; set; } = [];
}
