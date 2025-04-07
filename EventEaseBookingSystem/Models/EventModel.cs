using System;
using System.ComponentModel.DataAnnotations;

namespace EventEaseBookingSystem.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public string EventName { get; set; }
        public string VenueName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int VenueId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // Optional constructor
        public EventModel(string eventName, string venueName, string description, string imageUrl)
        {
            EventName = eventName;
            VenueName = venueName;
            Description = description;
            ImageUrl = imageUrl;
            Date = DateTime.Now;
        }

        // Parameterless constructor is required for EF Core
       
    }
}
