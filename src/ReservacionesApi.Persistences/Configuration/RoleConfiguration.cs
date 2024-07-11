using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A639D6EDF");

        builder.Property(e => e.RoleId).HasColumnName("RoleID");
        builder.Property(e => e.RoleName).HasMaxLength(50);
    }
}
