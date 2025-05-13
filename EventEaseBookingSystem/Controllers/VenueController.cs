
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventEaseBookingSystem.Data;
using EventEaseBookingSystem.Models;
using System.Threading.Tasks;

namespace EventEaseBookingSystem.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Venue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VenueName,Location,Address,Description,ImageUrl")] VenueModel venueModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venueModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venueModel);
        }

        // GET: Venue/Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Venues.ToListAsync());
        }
    }
}
