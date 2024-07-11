using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3B97F347");

        builder.Property(e => e.UserId).HasColumnName("UserID");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Email).HasMaxLength(255);
        builder.Property(e => e.EmailVerified).HasDefaultValue(false);
        builder.Property(e => e.FullName).HasMaxLength(255);
        builder.Property(e => e.PasswordHash).HasMaxLength(255);
        builder.Property(e => e.PhoneNumber).HasMaxLength(20);
        builder
            .Property(e => e.UpdatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.UserName).HasMaxLength(100);

        builder
            .HasMany(d => d.Roles)
            .WithMany(p => p.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                r =>
                    r.HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__RoleI__02084FDA"),
                l =>
                    l.HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__UserI__01142BA1"),
                j =>
                {
                    j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF27604FD51585FD");
                    j.ToTable("UserRoles");
                    j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                    j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                }
            );
    }
}
