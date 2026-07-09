using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Data;
using MVCApplication.Models;
using System.Diagnostics;

namespace MVCApplication.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }


    //Get - Shows data on UI
    public async Task<IActionResult> Index()
    {
        var model = new InterviewEntryViewModel
        {
            Applications = await _context.JobApplications
                .Include(x => x.Company)
                .OrderByDescending(x => x.AppliedDate)
                .ToListAsync()
        };

        return View(model);
    }


    // Saves new entry
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(InterviewEntryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Applications = await _context.JobApplications
                .Include(x => x.Company)
                .OrderByDescending(x => x.AppliedDate)
                .ToListAsync();

            return View(model);
        }

        var company = await _context.Companies
            .FirstOrDefaultAsync(x => x.Name == model.CompanyName);

        if (company == null)
        {
            company = new Company
            {
                Name = model.CompanyName,
                Website = model.Website,
                Industry = model.Industry,
                CreatedDate = DateTime.Now
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        var jobApplication = new JobApplication
        {
            CompanyId = company.Id,
            RoleTitle = model.RoleTitle,
            AppliedDate = model.AppliedDate,
            JobLink = model.JobLink,
            SalaryExpectation = model.SalaryExpectation,
            Status = model.Status,
            Notes = model.Notes,
            CreatedDate = DateTime.Now
        };

        _context.JobApplications.Add(jobApplication);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }



    // Update status
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        var jobApplication = await _context.JobApplications.FindAsync(id);

        if(jobApplication == null)
        {
            return NotFound();
        }

        jobApplication.Status = status;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}