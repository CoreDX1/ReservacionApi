using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F046153AC40");

        builder.Property(e => e.ReservationId).HasColumnName("ReservationID");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.PropertyId).HasColumnName("PropertyID");
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
        builder
            .Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.UserId).HasColumnName("UserID");

        builder
            .HasOne(d => d.Property)
            .WithMany(p => p.Reservations)
            .HasForeignKey(d => d.PropertyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Reservati__Prope__68487DD7");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.Reservations)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Reservati__UserI__693CA210");
    }
}
