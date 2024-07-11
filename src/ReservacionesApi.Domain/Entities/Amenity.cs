namespace ReservacionesApi.Domain.Entities;

public partial class Amenity
{
    public int AmenityId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
