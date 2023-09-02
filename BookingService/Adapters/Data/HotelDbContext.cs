using Data.Guest;
using Data.Room;
using Entities = Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class HotelDbContext : DbContext
{
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

    public DbSet<Entities.Guest> Guests { get; set; } = null!;
    public DbSet<Entities.Room> Rooms { get; set; } = null!;
    public DbSet<Entities.Booking> Bookings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GuestConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
    }
}
