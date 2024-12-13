using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class InteractionLog
{
    public int LogId { get; set; }

    public string? LogType { get; set; }

    public byte[] TimeStamp { get; set; } = null!;

    public int? LogDuration { get; set; }

    public int? LearnerId { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual ICollection<LearningActivity> LearningActivities { get; set; } = new List<LearningActivity>();
}
