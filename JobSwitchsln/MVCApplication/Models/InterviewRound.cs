using System;
using System.Collections.Generic;

namespace MVCApplication.Models;

public partial class InterviewRound
{
    public int Id { get; set; }

    public int JobApplicationId { get; set; }

    public string RoundName { get; set; } = null!;

    public DateTime ScheduledDate { get; set; }

    public string? InterviewerName { get; set; }

    public string Result { get; set; } = null!;

    public string? Feedback { get; set; }

    public int? DurationMinutes { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual JobApplication JobApplication { get; set; } = null!;
}
