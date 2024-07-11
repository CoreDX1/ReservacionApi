namespace ReservacionesApi.Domain.Entities;

public partial class Mesa
{
    public int MesaId { get; set; }

    public int NumeroMesa { get; set; }

    public int Capacidad { get; set; }

    public string? Ubicacion { get; set; }

    public virtual ICollection<Reservacione> Reservaciones { get; set; } = new List<Reservacione>();
}
