using MediatR;
using ReservacionesApi.Domain.Common;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Application.Features.Users.Commands.CreateUser;

// TOREVIEW: Investigar que hace IRequest
public class CreateUserCommand : IRequest<ApiResult<User>>
{
    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public bool? EmailVerified { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    // Clase Mediador
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResult<User>>
    {
        public async Task<ApiResult<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken) { }
    }
}
