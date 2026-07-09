using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models;

public class InterviewEntryViewModel
{
    [Required]
    [Display(Name = "Company Name")]
    public string CompanyName { get; set; } = string.Empty;

    public string? Website { get; set; }

    public string? Industry { get; set; }

    [Required]
    [Display(Name = "Role Title")]
    public string RoleTitle { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Applied Date")]
    public DateTime AppliedDate { get; set; } = DateTime.Today;

    [Display(Name = "Job Link")]
    public string? JobLink { get; set; }

    [Display(Name = "Salary Expectation")]
    public decimal? SalaryExpectation { get; set; }

    [Required]
    public string Status { get; set; } = "Applied";

    public string? Notes { get; set; }

    public List<JobApplication> Applications { get; set; } = new();
}