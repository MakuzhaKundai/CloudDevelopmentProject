using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventEaseBookingSystem.Data;
using EventEaseBookingSystem.Models;
using System.Threading.Tasks;

namespace EventEaseBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookingId,EventName,VenuName,StartDate,EndDate")] BookingModel bookingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingModel);
        }

        // GET: Booking/Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.ToListAsync());
        }
    }
}



