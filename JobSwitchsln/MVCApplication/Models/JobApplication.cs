using System;
using System.Collections.Generic;

namespace MVCApplication.Models;

public partial class JobApplication
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public string RoleTitle { get; set; } = null!;

    public DateTime AppliedDate { get; set; }

    public string? JobLink { get; set; }

    public decimal? SalaryExpectation { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<InterviewRound> InterviewRounds { get; set; } = new List<InterviewRound>();
}
