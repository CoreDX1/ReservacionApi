using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReservacionesApi.Persistences.Migrations;

public partial class ReservacionDbContext : DbContext
{
    public ReservacionDbContext()
    {
    }

    public ReservacionDbContext(DbContextOptions<ReservacionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertyImage> PropertyImages { get; set; }

    public virtual DbSet<Reservacione> Reservaciones { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.29.25.99;Database=ReservacionDB;Trusted_Connection=false;User ID=sa;Password=index#123;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("PK__Amenitie__842AF52B9DDEEC20");

            entity.Property(e => e.AmenityId).HasColumnName("AmenityID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A75FF9F6BB");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.HorarioId).HasName("PK__Horarios__BB881A9EA8C82E92");

            entity.Property(e => e.HorarioId).HasColumnName("HorarioID");
        });

        modelBuilder.Entity<LoginAttempt>(entity =>
        {
            entity.HasKey(e => e.AttemptId).HasName("PK__LoginAtt__891A6886ACA2C2D1");

            entity.Property(e => e.AttemptId).HasColumnName("AttemptID");
            entity.Property(e => e.AttemptTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.LoginAttempts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoginAtte__UserI__09A971A2");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PK__Mesas__6A4196C8CCC8973A");

            entity.Property(e => e.MesaId).HasColumnName("MesaID");
            entity.Property(e => e.Ubicacion).HasMaxLength(100);
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.ResetId).HasName("PK__Password__783CF7AD4A6AE763");

            entity.Property(e => e.ResetId).HasColumnName("ResetID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Expiration).HasColumnType("datetime");
            entity.Property(e => e.ResetToken).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.PasswordResets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PasswordR__UserI__0D7A0286");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A588CF77FE8");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Reserv__6D0D32F4");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Properti__70C9A755A0CE3295");

            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AverageRating).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.PricePerNight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Owner).WithMany(p => p.Properties)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Propertie__Owner__6383C8BA");

            entity.HasMany(d => d.Amenities).WithMany(p => p.Properties)
                .UsingEntity<Dictionary<string, object>>(
                    "PropertyAmenity",
                    r => r.HasOne<Amenity>().WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PropertyA__Ameni__7C4F7684"),
                    l => l.HasOne<Property>().WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PropertyA__Prope__7B5B524B"),
                    j =>
                    {
                        j.HasKey("PropertyId", "AmenityId").HasName("PK__Property__D88B0807652D3D2C");
                        j.ToTable("PropertyAmenities");
                        j.IndexerProperty<int>("PropertyId").HasColumnName("PropertyID");
                        j.IndexerProperty<int>("AmenityId").HasColumnName("AmenityID");
                    });
        });

        modelBuilder.Entity<PropertyImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Property__7516F4ECC604F1E1");

            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("ImageURL");
            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

            entity.HasOne(d => d.Property).WithMany(p => p.PropertyImages)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PropertyI__Prope__70DDC3D8");
        });

        modelBuilder.Entity<Reservacione>(entity =>
        {
            entity.HasKey(e => e.ReservacionId).HasName("PK__Reservac__145B3EB5CA08C473");

            entity.Property(e => e.ReservacionId).HasColumnName("ReservacionID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.FechaReservacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HorarioId).HasColumnName("HorarioID");
            entity.Property(e => e.MesaId).HasColumnName("MesaID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Reservaci__Clien__5070F446");

            entity.HasOne(d => d.Horario).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.HorarioId)
                .HasConstraintName("FK__Reservaci__Horar__52593CB8");

            entity.HasOne(d => d.Mesa).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.MesaId)
                .HasConstraintName("FK__Reservaci__MesaI__5165187F");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F046153AC40");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Property).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Prope__68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__693CA210");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE43AC403D");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Property).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Propert__75A278F5");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__UserID__76969D2E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A639D6EDF");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PK__Tokens__658FEE8ADCB49041");

            entity.Property(e => e.TokenId).HasColumnName("TokenID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Expiration).HasColumnType("datetime");
            entity.Property(e => e.Token1)
                .HasMaxLength(255)
                .HasColumnName("Token");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tokens__UserID__05D8E0BE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3B97F347");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EmailVerified).HasDefaultValue(false);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__RoleI__02084FDA"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRoles__UserI__01142BA1"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF27604FD51585FD");
                        j.ToTable("UserRoles");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
