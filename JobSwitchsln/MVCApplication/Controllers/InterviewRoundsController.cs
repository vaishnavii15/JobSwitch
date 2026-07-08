
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Models;
using MVCApplication.Data;

public class InterviewRoundsController : Controller
{
    private readonly AppDbContext _context;

    public InterviewRoundsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: INTERVIEWROUNDS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.InterviewRounds.ToListAsync());
    }

    // GET: INTERVIEWROUNDS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var interviewround = await _context.InterviewRounds
            .FirstOrDefaultAsync(m => m.Id == id);
        if (interviewround == null)
        {
            return NotFound();
        }

        return View(interviewround);
    }

    // GET: INTERVIEWROUNDS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: INTERVIEWROUNDS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,JobApplicationId,RoundName,ScheduledDate,InterviewerName,Result,Feedback,DurationMinutes,CreatedDate,JobApplication")] InterviewRound interviewround)
    {
        if (ModelState.IsValid)
        {
            _context.Add(interviewround);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(interviewround);
    }

    // GET: INTERVIEWROUNDS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var interviewround = await _context.InterviewRounds.FindAsync(id);
        if (interviewround == null)
        {
            return NotFound();
        }
        return View(interviewround);
    }

    // POST: INTERVIEWROUNDS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,JobApplicationId,RoundName,ScheduledDate,InterviewerName,Result,Feedback,DurationMinutes,CreatedDate,JobApplication")] InterviewRound interviewround)
    {
        if (id != interviewround.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(interviewround);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewRoundExists(interviewround.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(interviewround);
    }

    // GET: INTERVIEWROUNDS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var interviewround = await _context.InterviewRounds
            .FirstOrDefaultAsync(m => m.Id == id);
        if (interviewround == null)
        {
            return NotFound();
        }

        return View(interviewround);
    }

    // POST: INTERVIEWROUNDS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var interviewround = await _context.InterviewRounds.FindAsync(id);
        if (interviewround != null)
        {
            _context.InterviewRounds.Remove(interviewround);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InterviewRoundExists(int? id)
    {
        return _context.InterviewRounds.Any(e => e.Id == id);
    }



}
SSSS