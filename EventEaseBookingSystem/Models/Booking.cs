public class BookingModel
{
    public int Id { get; set; }
    public string BookingId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int EventId { get; set; }
    public EventModel? Event { get; set; }

    public int VenueId { get; set; }
    public VenueModel? Venue { get; set; }
}

