using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class SkillProgressionChallengingTask
{
    public int? SkillProgressionId { get; set; }

    public string? ChallengingTask { get; set; }

    public virtual SkillProgression? SkillProgression { get; set; }
}
