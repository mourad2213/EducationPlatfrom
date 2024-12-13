using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class EmotionalFeedback
{
    public int FeedbackId { get; set; }

    public string? EmotionalState { get; set; }

    public byte[] FeedbackTime { get; set; } = null!;

    public int? LearnerId { get; set; }

    public int? ActivityId { get; set; }

    public int? InstructorId { get; set; }

    public virtual LearningActivity? Activity { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual Learner? Learner { get; set; }
}
