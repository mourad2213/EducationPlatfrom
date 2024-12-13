using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearningPath
{
    public int PathId { get; set; }

    public string? Rules { get; set; }

    public string? LearnerStatus { get; set; }

    public string? PathDescription { get; set; }

    public int? InstructorId { get; set; }

    public int? LearnerId { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual ICollection<PersonalizationProfile> PersonalizationProfiles { get; set; } = new List<PersonalizationProfile>();
}
