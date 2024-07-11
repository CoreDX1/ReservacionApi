using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Configuration;

public class TokenConfiguration : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.HasKey(e => e.TokenId).HasName("PK__Tokens__658FEE8ADCB49041");

        builder.Property(e => e.TokenId).HasColumnName("TokenID");
        builder
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("(getdate())")
            .HasColumnType("datetime");
        builder.Property(e => e.Expiration).HasColumnType("datetime");
        builder.Property(e => e.Token1).HasMaxLength(255).HasColumnName("Token");
        builder.Property(e => e.UserId).HasColumnName("UserID");

        builder
            .HasOne(d => d.User)
            .WithMany(p => p.Tokens)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__Tokens__UserID__05D8E0BE");
    }
}
