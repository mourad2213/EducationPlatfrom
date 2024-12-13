using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseTitle { get; set; } = null!;

    public int? CourseCreditHours { get; set; }

    public string? CourseDescription { get; set; }

    public string? DifficultyLevel { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<CourseLearningObjective> CourseLearningObjectives { get; set; } = new List<CourseLearningObjective>();

    public virtual CoursePrerequisite? CoursePrerequisite { get; set; }

    public virtual ICollection<Leaderboard> Leaderboards { get; set; } = new List<Leaderboard>();

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();

    public virtual ICollection<LearningActivity> LearningActivities { get; set; } = new List<LearningActivity>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Learner> LearnersNavigation { get; set; } = new List<Learner>();
}
