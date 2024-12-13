using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Achievement
{
    public int AchievementId { get; set; }

    public string? AchievementDescription { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Badge> Badges { get; set; } = new List<Badge>();

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
