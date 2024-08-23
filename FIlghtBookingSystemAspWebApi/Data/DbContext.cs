using FIlghtBookingSystemAspWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FIlghtBookingSystemAspWebApi.Data
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {

        // Constructor to pass DbContext options to the base DbContext class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties representing tables in the database

        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<FlightDetails> FlightDetails { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<CheckInStatus> CheckInStatuses { get; set; }

        // Override method to configure the model and relationships between entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetails>()
                .HasOne(b => b.User)       // Each BookingDetails entity has one User
                .WithMany(u => u.BookingDetails)     // Each User entity has many BookingDetails
                .HasForeignKey(b => b.User_ID);     // Foreign key in BookingDetails entity pointing to User entity
        }

    }
}
