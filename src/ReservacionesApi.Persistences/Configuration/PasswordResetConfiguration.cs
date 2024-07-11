using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class PasswordResetConfiguration : IEntityTypeConfiguration<PasswordReset>
{
    public void Configure(EntityTypeBuilder<PasswordReset> builder)
    {
        builder.HasKey(e => e.ResetId).HasName("PK__Password__783CF7AD4A6AE763");

        builder.Property(e => e.ResetId).HasColumnName("ResetID");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Expiration).HasColumnType("datetime");
        builder.Property(e => e.ResetToken).HasMaxLength(255);
        builder.Property(e => e.UserId).HasColumnName("UserID");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.PasswordResets)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__PasswordR__UserI__0D7A0286");
    }
}
