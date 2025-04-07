using EventEaseBookingSystem.Data;
using EventEaseBookingSystem.Models;  // Ensure this is at the top
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
    {
        if (context.Events.Any())
        {
            return;   // DB has been seeded
        }

        context.Events.AddRange(
            new EventModel("Tech Conference", "Expo Center", "A full-day tech conference.", "https://via.placeholder.com/150") { Date = DateTime.Now.AddDays(10) },
            new EventModel("Music Festival", "Open Grounds", "Live music all day long!", "https://via.placeholder.com/150") { Date = DateTime.Now.AddDays(20) }
        );

        context.SaveChanges();
    }

    internal static void Initialize(IServiceProvider services)
    {
        throw new NotImplementedException();
    }
}
