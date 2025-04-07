
using EventEaseBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEaseBookingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<VenueModel> Venues { get; set; }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
    }
}