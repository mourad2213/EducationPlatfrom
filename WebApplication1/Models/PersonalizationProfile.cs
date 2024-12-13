using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class PersonalizationProfile
{
    public int PersonalizationProfileId { get; set; }

    public int? LearnerId { get; set; }

    public int? PathId { get; set; }

    public string? PersonalityType { get; set; }

    public string? PreferedContentType { get; set; }

    public string? CurrentEmotionalState { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual ICollection<LearningPath> Paths { get; set; } = new List<LearningPath>();
}
