using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearningActivity
{
    public int ActivityId { get; set; }

    public string? ActivityType { get; set; }

    public string? DetailedInstructions { get; set; }

    public int? MaxPoints { get; set; }

    public int? ModuleId { get; set; }

    public int? LogId { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual InteractionLog? Log { get; set; }

    public virtual Module? Module { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
