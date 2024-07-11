namespace ReservacionesApi.Domain.Entities;

public partial class PropertyImage
{
    public int ImageId { get; set; }

    public int PropertyId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Property Property { get; set; } = null!;
}
