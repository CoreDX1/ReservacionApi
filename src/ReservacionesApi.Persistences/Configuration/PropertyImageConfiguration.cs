using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
{
    public void Configure(EntityTypeBuilder<PropertyImage> builder)
    {
        builder.HasKey(e => e.ImageId).HasName("PK__Property__7516F4ECC604F1E1");

        builder.Property(e => e.ImageId).HasColumnName("ImageID");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.ImageUrl).HasMaxLength(255).HasColumnName("ImageURL");
        builder.Property(e => e.PropertyId).HasColumnName("PropertyID");

        builder
            .HasOne(d => d.Property)
            .WithMany(p => p.PropertyImages)
            .HasForeignKey(d => d.PropertyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__PropertyI__Prope__70DDC3D8");
    }
}
