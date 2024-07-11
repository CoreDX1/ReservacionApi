using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(e => e.PropertyId).HasName("PK__Properti__70C9A755A0CE3295");

        builder.Property(e => e.PropertyId).HasColumnName("PropertyID");
        builder.Property(e => e.Address).HasMaxLength(255);
        builder.Property(e => e.AverageRating).HasColumnType("decimal(3, 2)");
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Country).HasMaxLength(100);
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Name).HasMaxLength(255);
        builder.Property(e => e.OwnerId).HasColumnName("OwnerID");
        builder.Property(e => e.PricePerNight).HasColumnType("decimal(10, 2)");
        builder.Property(e => e.State).HasMaxLength(100);
        builder
            .Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");

        builder
            .HasOne(d => d.Owner)
            .WithMany(p => p.Properties)
            .HasForeignKey(d => d.OwnerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Propertie__Owner__6383C8BA");

        builder
            .HasMany(d => d.Amenities)
            .WithMany(p => p.Properties)
            .Usingbuilder<Dictionary<string, object>>(
                "PropertyAmenity",
                r =>
                    r.HasOne<Amenity>()
                        .WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PropertyA__Ameni__7C4F7684"),
                l =>
                    l.HasOne<Property>()
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PropertyA__Prope__7B5B524B"),
                j =>
                {
                    j.HasKey("PropertyId", "AmenityId").HasName("PK__Property__D88B0807652D3D2C");
                    j.ToTable("PropertyAmenities");
                    j.IndexerProperty<int>("PropertyId").HasColumnName("PropertyID");
                    j.IndexerProperty<int>("AmenityId").HasColumnName("AmenityID");
                }
            );
    }
}
