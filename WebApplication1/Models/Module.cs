using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public partial class Module
{
    [Key]
    public int ModuleId { get; set; }

    public string? LevelOfDifficulty { get; set; }

    public string? ContentType { get; set; }

    public int? CourseId { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<ContentLibrary> ContentLibraries { get; set; } = new List<ContentLibrary>();

    public virtual Course? Course { get; set; }

    public virtual ICollection<DiscussionForum> DiscussionForums { get; set; } = new List<DiscussionForum>();

    public virtual ICollection<LearningActivity> LearningActivities { get; set; } = new List<LearningActivity>();

    public virtual ICollection<ModulesLink> ModulesLinks { get; set; } = new List<ModulesLink>();

    public virtual ICollection<ModulesTargetTrait> ModulesTargetTraits { get; set; } = new List<ModulesTargetTrait>();

    public virtual ICollection<LearningActivity> Activities { get; set; } = new List<LearningActivity>();
}
