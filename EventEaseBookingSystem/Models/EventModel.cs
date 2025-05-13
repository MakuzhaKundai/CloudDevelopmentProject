
using EventEaseBookingSystem.Models;

public class EventModel
{
    public int Id { get; set; }
    public string Title { get; set; } // ← Not "Name"
    public string Description { get; set; }
    public DateTime EventDate { get; set; } // ← Not "Date"
    public int VenueId { get; set; }

    public VenueModel? Venue { get; set; }
}

