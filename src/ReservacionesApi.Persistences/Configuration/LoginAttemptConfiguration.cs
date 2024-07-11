using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class LoginAttemptConfiguration : IEntityTypeConfiguration<LoginAttempt>
{
    public void Configure(EntityTypeBuilder<LoginAttempt> builder)
    {
        builder.HasKey(e => e.AttemptId).HasName("PK__LoginAtt__891A6886ACA2C2D1");

        builder.Property(e => e.AttemptId).HasColumnName("AttemptID");
        builder
            .Property(e => e.AttemptTime)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.UserId).HasColumnName("UserID");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.LoginAttempts)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__LoginAtte__UserI__09A971A2");
    }
}
