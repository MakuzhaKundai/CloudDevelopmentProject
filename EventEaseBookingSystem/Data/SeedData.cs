using System.Linq;
using EventEaseBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEaseBookingSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any events.
            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new EventModel
                    {
                        Title = "Sample Event 1",
                        Description = "Description of Sample Event 1",
                        Date = new DateTime(2025, 6, 1),
                        VenueName = "Venue 1",
                        Location = "Location 1"
                    },
                    new EventModel
                    {
                        Title = "Sample Event 2",
                        Description = "Description of Sample Event 2",
                        Date = new DateTime(2025, 7, 1),
                        VenueName = "Venue 2",
                        Location = "Location 2"
                    }
                );
                context.SaveChanges();
            }

            // Look for any venues
            if (!context.Venues.Any())
            {
                context.Venues.AddRange(
                    new VenueModel
                    {
                        VenueName = "Venue 1",
                        Location = "Location 1",
                        Address = "Address 1",
                        Description = "Description for Venue 1",
                        ImageUrl = "image1.jpg"
                    },
                    new VenueModel
                    {
                        VenueName = "Venue 2",
                        Location = "Location 2",
                        Address = "Address 2",
                        Description = "Description for Venue 2",
                        ImageUrl = "image2.jpg"
                    }
                );
                context.SaveChanges();
            }

            // Look for any bookings
            if (!context.Bookings.Any())
            {
                context.Bookings.AddRange(
                    new BookingModel
                    {
                        BookingId = "Booking1",
                        EventName = "Sample Event 1",
                        VenueName = "Venue 1",
                        StartDate = new DateTime(2025, 6, 1),
                        EndDate = new DateTime(2025, 6, 2)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
