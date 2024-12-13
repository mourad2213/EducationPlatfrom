using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Learner
{
    public int LearnerId { get; set; }

    public string LearnerName { get; set; } = null!;

    public string? LearnerGender { get; set; }

    public string? CountryOfOrigin { get; set; }

    public string? ExperienceLevel { get; set; }

    public int? LearnerAge { get; set; }

    public DateOnly LearnerBirthdayDate { get; set; }

    public int? CourseId { get; set; }

    public int? BoardId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual ICollection<InteractionLog> InteractionLogs { get; set; } = new List<InteractionLog>();

    public virtual Leaderboard? Leaderboard { get; set; }

    public virtual ICollection<LearnerAssessment> LearnerAssessments { get; set; } = new List<LearnerAssessment>();

    public virtual ICollection<LearnerDiscussionForum> LearnerDiscussionForums { get; set; } = new List<LearnerDiscussionForum>();

    public virtual ICollection<LearnerNotification> LearnerNotifications { get; set; } = new List<LearnerNotification>();

    public virtual ICollection<LearnerQuest> LearnerQuests { get; set; } = new List<LearnerQuest>();

    public virtual ICollection<LearningGoal> LearningGoals { get; set; } = new List<LearningGoal>();

    public virtual ICollection<LearningPath> LearningPaths { get; set; } = new List<LearningPath>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<PersonalizationProfile> PersonalizationProfiles { get; set; } = new List<PersonalizationProfile>();

    public virtual ICollection<Reward> Rewards { get; set; } = new List<Reward>();

    public virtual ICollection<SkillProgression> SkillProgressions { get; set; } = new List<SkillProgression>();

    public virtual ICollection<Survey> SurveysNavigation { get; set; } = new List<Survey>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Badge> Badges { get; set; } = new List<Badge>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();
}
