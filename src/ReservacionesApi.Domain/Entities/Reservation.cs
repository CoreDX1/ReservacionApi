namespace ReservacionesApi.Domain.Entities;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int PropertyId { get; set; }

    public int UserId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Property Property { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
