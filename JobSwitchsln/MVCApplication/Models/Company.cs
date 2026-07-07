using System;
using System.Collections.Generic;

namespace MVCApplication.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Website { get; set; }

    public string? Industry { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}
