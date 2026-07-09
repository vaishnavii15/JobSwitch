using Microsoft.AspNetCore.Mvc;
using MVCApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace MVCApplication.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext contex)
        {
            _context = contex;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> StatusChart()
        {
            var statusCounts = await _context.JobApplications
                .GroupBy(x => x.Status)
                .Select(x => new
                {
                    Status = x.Key,
                    Count = x.Count()
                })
                .OrderBy(x => x.Status)
                .ToListAsync();

            ViewBag.StatusLabels = statusCounts.Select(x => x.Status).ToList();
            ViewBag.StatusCounts = statusCounts.Select(x => x.Count).ToList();

            return View();
        }
    }
}
