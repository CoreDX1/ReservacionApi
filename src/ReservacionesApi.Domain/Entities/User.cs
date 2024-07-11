namespace ReservacionesApi.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? EmailVerified { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<LoginAttempt> LoginAttempts { get; set; } = new List<LoginAttempt>();

    public virtual ICollection<PasswordReset> PasswordResets { get; set; } =
        new List<PasswordReset>();

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
