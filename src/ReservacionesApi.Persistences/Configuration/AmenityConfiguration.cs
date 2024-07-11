using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.HasKey(e => e.AmenityId).HasName("PK__Amenitie__842AF52B9DDEEC20");

        builder.Property(e => e.AmenityId).HasColumnName("AmenityID");
        builder.Property(e => e.Name).HasMaxLength(100);
    }
}
