using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearnerAssessment
{
    public int LearnerId { get; set; }

    public int AssessmentId { get; set; }

    public int? Points { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
