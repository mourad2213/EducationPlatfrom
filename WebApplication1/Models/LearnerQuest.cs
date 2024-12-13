using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearnerQuest
{
    public int QuestId { get; set; }

    public int LearnerId { get; set; }

    public string? CompletionStatus { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Quest Quest { get; set; } = null!;
}
