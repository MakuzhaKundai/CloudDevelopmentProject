using Microsoft.AspNetCore.Mvc;
using EventEaseBookingSystem.Models;

namespace EventEaseBookingSystem.Controllers
{
    public class VenueController : Controller
    {
        public IActionResult Index()
        {
            var venues = new List<VenueModel>
            {
                new VenueModel { Id = 1, Name = "Monte Casino", Location = "Fourways Sandton", Capacity = 300, ImageUrl = "https://via.placeholder.com/300x200?text=Venue+1" },
                new VenueModel { Id = 2, Name = "FNB Stadium", Location = "Uptown", Capacity = 1000, ImageUrl = "https://via.placeholder.com/300x200?text=Venue+2" }
            };

            return View(venues);
        }
    }
}
