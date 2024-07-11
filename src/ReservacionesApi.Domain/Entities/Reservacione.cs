namespace ReservacionesApi.Domain.Entities;

public partial class Reservacione
{
    public int ReservacionId { get; set; }

    public int? ClienteId { get; set; }

    public int? MesaId { get; set; }

    public int? HorarioId { get; set; }

    public DateTime? FechaReservacion { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Horario? Horario { get; set; }

    public virtual Mesa? Mesa { get; set; }
}
