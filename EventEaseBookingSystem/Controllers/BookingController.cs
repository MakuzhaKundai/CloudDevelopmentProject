using Microsoft.AspNetCore.Mvc;
using EventEaseBookingSystem.Data;
using EventEaseBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Booking/Index
    public async Task<IActionResult> Index()
    {
        // Fetching all bookings from the database
        var bookings = await _context.Bookings.ToListAsync();
        return View(bookings);  // Passing the list of bookings to the view
    }

    // GET: Booking/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);  // Passing the booking object to the view
    }

    // POST: Booking/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,BookingId,EventName,VenueName,StartDate,EndDate")] BookingModel booking)
    {
        if (id != booking.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // Update the booking in the database
                _context.Update(booking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(booking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));  // Redirect to the Index page after saving the changes
        }
        return View(booking);  // Return the view with validation errors if any
    }

    // Helper method to check if the booking exists in the database
    private bool BookingExists(int id)
    {
        return _context.Bookings.Any(e => e.Id == id);
    }
}
