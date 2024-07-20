namespace ReservacionesApi.Application.Dtos.User.Request;

public class UserLoginRequestDto
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
