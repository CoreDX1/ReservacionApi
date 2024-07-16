using Microsoft.EntityFrameworkCore;
using ReservacionesApi.Domain.Entities;

namespace ReservacionesApi.Persistences.Migrations;

public partial class ReservacionDbContext : DbContext
{
    public ReservacionDbContext() { }

    public ReservacionDbContext(DbContextOptions<ReservacionDbContext> options)
        : base(options)
    {
        // TOREVIEW: Investigar que hace el ChangeTracker
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<Amenity> Amenities { get; set; }

    public DbSet<LoginAttempt> LoginAttempts { get; set; }

    public DbSet<PasswordReset> PasswordResets { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Property> Properties { get; set; }

    public DbSet<PropertyImage> PropertyImages { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Token> Tokens { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReservacionDbContext).Assembly);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
