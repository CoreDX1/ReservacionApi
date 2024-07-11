namespace ReservacionesApi.Domain.Entities;

public partial class Property
{
    public int PropertyId { get; set; }

    public int OwnerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Address { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public decimal? AverageRating { get; set; }

    public decimal PricePerNight { get; set; }

    public int MaxGuests { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<PropertyImage> PropertyImages { get; set; } =
        new List<PropertyImage>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
}
