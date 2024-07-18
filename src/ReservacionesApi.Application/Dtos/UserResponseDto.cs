namespace ReservacionesApi.Application.Dtos;

public record UserResponseDto(int UserId, string UserName, string Email, string FullName, string? PhoneNumber);
