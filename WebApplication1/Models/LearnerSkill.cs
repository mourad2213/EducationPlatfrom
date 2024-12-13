using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearnerSkill
{
    public int? LearnerId { get; set; }

    public string? LearnerSkills { get; set; }

    public virtual Learner? Learner { get; set; }
}
