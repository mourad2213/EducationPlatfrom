using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class SkillProgression
{
    public int SkillProgressionId { get; set; }

    public int? ProficiencyLevel { get; set; }

    public int? LearnerId { get; set; }

    public virtual Learner? Learner { get; set; }
}
