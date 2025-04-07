using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEaseBookingSystem.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public string BookingId { get; set; } = string.Empty;
        public string EventName { get; set; } = string.Empty;
        public string VenueName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
