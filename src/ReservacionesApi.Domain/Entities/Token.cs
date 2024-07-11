namespace ReservacionesApi.Domain.Entities;

public partial class Token
{
    public int TokenId { get; set; }

    public int UserId { get; set; }

    public string Token1 { get; set; } = null!;

    public DateTime Expiration { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
