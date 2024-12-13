using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearningGoal
{
    public int GoalId { get; set; }

    public string? Description { get; set; }

    public DateOnly? Deadline { get; set; }

    public string? Status { get; set; }

    public int? LearnerId { get; set; }

    public virtual Learner? Learner { get; set; }
}
