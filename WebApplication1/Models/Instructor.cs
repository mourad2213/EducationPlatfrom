using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string? InstructorName { get; set; }

    public string? ExpertiseAreas { get; set; }

    public string? Qualifications { get; set; }
    public string UserId { get; set; } // Ensure this property exists
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();


    public virtual UserAcccount UserAccount { get; set; } // Navigation property to UserAccount
    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual ICollection<InstructorEmail> Emails { get; set; } = new List<InstructorEmail>();

    public virtual ICollection<LearningPath> LearningPaths { get; set; } = new List<LearningPath>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
