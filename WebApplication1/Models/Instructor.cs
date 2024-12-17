using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string? InstructorName { get; set; }

    public string? ExpertiseAreas { get; set; }

    public string? Qualifications { get; set; }
    public string UserId { get; set; }
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual ICollection<InstructorEmail> InstructorEmails { get; set; } = new List<InstructorEmail>();

    public virtual ICollection<LearningPath> LearningPaths { get; set; } = new List<LearningPath>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
