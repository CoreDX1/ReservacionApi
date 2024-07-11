namespace ReservacionesApi.Domain.Entities;

public partial class LoginAttempt
{
    public int AttemptId { get; set; }

    public int UserId { get; set; }

    public DateTime? AttemptTime { get; set; }

    public bool? Success { get; set; }

    public virtual User User { get; set; } = null!;
}
