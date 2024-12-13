using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Assessment
{
    public int AssessmentId { get; set; }

    public string? GradingCriteria { get; set; }

    public int? Weight { get; set; }

    public string? Title { get; set; }

    public int? MaxScore { get; set; }

    public string? Description { get; set; }

    public int? CourseId { get; set; }

    public int? InstructorId { get; set; }

    public int? ModuleId { get; set; }

    public int? Grade { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual ICollection<LearnerAssessment> LearnerAssessments { get; set; } = new List<LearnerAssessment>();

    public virtual Module? Module { get; set; }
}
