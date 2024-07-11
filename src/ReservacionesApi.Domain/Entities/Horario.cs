namespace ReservacionesApi.Domain.Entities;

public partial class Horario
{
    public int HorarioId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<Reservacione> Reservaciones { get; set; } = new List<Reservacione>();
}
