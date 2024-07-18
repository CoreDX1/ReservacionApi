namespace ReservacionesApi.Domain.Common;

public class UserResponseDto
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }
}
