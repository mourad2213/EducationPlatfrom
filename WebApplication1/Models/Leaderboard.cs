using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Leaderboard
{
    public int? TotalPoints { get; set; }

    public int CourseId { get; set; }

    public int BoardId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
