namespace ReservacionesAPI.Models;

public class ApiResponse<T>
{
    public List<string>? Message { get; set; }
    public T? Data { get; set; }
    public int Status { get; set; }
}

public class Validation
{
    public List<string> Message { get; set; } = [];

    public void AddMessage(string message)
    {
        Message.Add(message);
    }
}
