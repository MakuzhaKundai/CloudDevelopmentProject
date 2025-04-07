using Microsoft.AspNetCore.Mvc;
using EventEaseBookingSystem.Data;
using EventEaseBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

public class EventController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Event/Index
    public async Task<IActionResult> Index()
    {
        var events = await _context.Events.ToListAsync();
        return View(events);  // Passing the list of events to the view
    }

    // GET: Event/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }

        var eventModel = await _context.Events.FindAsync(id);
        if (eventModel == null)
        {
            return NotFound();
        }

        return View(eventModel);  // Passing the event object to the view
    }

    // POST: Event/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,EventName,VenueName,Description,ImageUrl,Date")] EventModel eventModel)
    {
        if (id != eventModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(eventModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(eventModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));  // Redirect to the Index page after saving changes
        }
        return View(eventModel);  // Return the view with validation errors if any
    }

    // Helper method to check if the event exists in the database
    private bool EventExists(int id)
    {
        return _context.Events.Any(e => e.Id == id);
    }
}
