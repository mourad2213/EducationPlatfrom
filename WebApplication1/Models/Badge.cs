using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Badge
{
    public int BadgeId { get; set; }

    public string? BadgeTitle { get; set; }

    public int? BadgePoints { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
