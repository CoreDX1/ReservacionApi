namespace ReservacionesApi.Application.Dtos;

public class UserRequestDto
{
    public string UserName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool? EmailVerified { get; set; }
    public string FullName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
