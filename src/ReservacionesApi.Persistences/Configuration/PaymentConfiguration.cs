using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A588CF77FE8");

        builder.Property(e => e.PaymentId).HasColumnName("PaymentID");
        builder.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
        builder
            .Property(e => e.PaymentDate)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.PaymentMethod).HasMaxLength(50);
        builder.Property(e => e.ReservationId).HasColumnName("ReservationID");
        builder.Property(e => e.TransactionId).HasMaxLength(100).HasColumnName("TransactionID");

        builder
            .HasOne(d => d.Reservation)
            .WithMany(p => p.Payments)
            .HasForeignKey(d => d.ReservationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Payments__Reserv__6D0D32F4");
    }
}
