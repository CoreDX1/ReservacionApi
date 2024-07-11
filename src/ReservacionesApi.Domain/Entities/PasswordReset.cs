namespace ReservacionesApi.Domain.Entities;

public partial class PasswordReset
{
    public int ResetId { get; set; }

    public int UserId { get; set; }

    public string ResetToken { get; set; } = null!;

    public DateTime Expiration { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
