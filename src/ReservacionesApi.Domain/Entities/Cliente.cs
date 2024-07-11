namespace ReservacionesApi.Domain.Entities;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Reservacione> Reservaciones { get; set; } = new List<Reservacione>();
}
