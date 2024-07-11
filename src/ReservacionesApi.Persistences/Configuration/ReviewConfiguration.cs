using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE43AC403D");

        builder.Property(e => e.ReviewId).HasColumnName("ReviewID");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.PropertyId).HasColumnName("PropertyID");
        builder.Property(e => e.UserId).HasColumnName("UserID");

        builder
            .HasOne(d => d.Property)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.PropertyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Reviews__Propert__75A278F5");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Reviews__UserID__76969D2E");
    }
}
