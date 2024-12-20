using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
//using WebApplication1.login;
namespace WebApplication1.Models;
public partial class MilestoneContext : IdentityDbContext<UserAcccount>
{
    public MilestoneContext()
    {
    }
    public MilestoneContext(DbContextOptions<MilestoneContext> options)
        : base(options)
    {
    }
    public DbSet<LearningPathProgress> LearningPathProgresses { get; set; }
    public DbSet<UserAcccount> UserAcccounts { get; set; }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }
    public DbSet<LearnerDiscussionForum> LearnerDiscussionForums { get; set; }
    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<CollaborativeQuest> CollaborativeQuests { get; set; }

    public virtual DbSet<ContentLibrary> ContentLibraries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<CourseLearningObjective> CourseLearningObjectives { get; set; }

    public virtual DbSet<CoursePrerequisite> CoursePrerequisites { get; set; }

    public virtual DbSet<DiscussionForum> DiscussionForums { get; set; }

    public virtual DbSet<DiscussionForumsLearner> DiscussionForumsLearners { get; set; }

    public virtual DbSet<EmotionalFeedback> EmotionalFeedbacks { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InstructorEmail> InstructorEmails { get; set; }

    public virtual DbSet<InteractionLog> InteractionLogs { get; set; }

    public virtual DbSet<Leaderboard> Leaderboards { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<LearnerAssessment> LearnerAssessments { get; set; }


    public virtual DbSet<LearnerNotification> LearnerNotifications { get; set; }

    public virtual DbSet<LearnerQuest> LearnerQuests { get; set; }

    public virtual DbSet<LearnerSkill> LearnerSkills { get; set; }

    public virtual DbSet<LearningActivity> LearningActivities { get; set; }

    public virtual DbSet<LearningGoal> LearningGoals { get; set; }

    public virtual DbSet<LearningPath> LearningPaths { get; set; }
    public DbSet<Post> Posts { get; set; }
    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<ModulesLink> ModulesLinks { get; set; }

    public virtual DbSet<ModulesTargetTrait> ModulesTargetTraits { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PersonalizationProfile> PersonalizationProfiles { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<SkillMasteryQuest> SkillMasteryQuests { get; set; }

    public virtual DbSet<SkillProgression> SkillProgressions { get; set; }

    public virtual DbSet<SkillProgressionChallengingTask> SkillProgressionChallengingTasks { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveysQuestion> SurveysQuestions { get; set; }
    public IEnumerable<object> UserAcccount { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Milestone;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Identity entities configuration
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

        // Achievement entity configuration
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__2A420CCBE5ED821F");

            entity.Property(e => e.AchievementId).HasColumnName("Achievement_ID");
            entity.Property(e => e.AchievementDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Achievement_Description");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasMany(d => d.Badges).WithMany(p => p.Achievements)
                .UsingEntity<Dictionary<string, object>>(
                    "AchievementBadge",
                    r => r.HasOne<Badge>().WithMany()
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Achieveme__Badge__5224328E"),
                    l => l.HasOne<Achievement>().WithMany()
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Achieveme__Achie__51300E55"),
                    j =>
                    {
                        j.HasKey("AchievementId", "BadgeId").HasName("PK__Achievem__797062FB352A10FE");
                        j.ToTable("AchievementBadges");
                        j.IndexerProperty<int>("AchievementId").HasColumnName("Achievement_ID");
                        j.IndexerProperty<int>("BadgeId").HasColumnName("Badge_ID");
                    });
        });



        // Additional configurations if any



        modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasKey(e => e.AssessmentId).HasName("PK__Assessme__6B3C1D928095953C");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_ID");
                entity.Property(e => e.CourseId).HasColumnName("Course_ID");
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.GradingCriteria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Grading_Criteria");
                entity.Property(e => e.InstructorId).HasColumnName("Instructor_ID");
                entity.Property(e => e.MaxScore).HasColumnName("Max_Score");
                entity.Property(e => e.ModuleId).HasColumnName("Module_ID");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course).WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Assessmen__Cours__2645B050");

                entity.HasOne(d => d.Instructor).WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK__Assessmen__Instr__2739D489");

                entity.HasOne(d => d.Module).WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK__Assessmen__Modul__282DF8C2");
            });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeId).HasName("PK__Badges__3326E30430BC55B3");

            entity.Property(e => e.BadgeId).HasColumnName("Badge_ID");
            entity.Property(e => e.BadgePoints).HasColumnName("Badge_Points");
            entity.Property(e => e.BadgeTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Badge_Title");

            entity.HasMany(d => d.Learners).WithMany(p => p.Badges)
                .UsingEntity<Dictionary<string, object>>(
                    "LearnerBadge",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerBa__Learn__0A9D95DB"),
                    l => l.HasOne<Badge>().WithMany()
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerBa__Badge__09A971A2"),
                    j =>
                    {
                        j.HasKey("BadgeId", "LearnerId").HasName("PK__LearnerB__D0F8C47B121C63BB");
                        j.ToTable("LearnerBadges");
                        j.IndexerProperty<int>("BadgeId").HasColumnName("Badge_ID");
                        j.IndexerProperty<int>("LearnerId").HasColumnName("Learner_ID");
                    });
        });

        modelBuilder.Entity<CollaborativeQuest>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__Collabor__6D9E739B6FD09241");

            entity.ToTable("CollaborativeQuest");

            entity.Property(e => e.QuestId)
                .ValueGeneratedNever()
                .HasColumnName("Quest_ID");
            entity.Property(e => e.MaxParticipants).HasColumnName("Max_Participants");

            entity.HasOne(d => d.Quest).WithOne(p => p.CollaborativeQuest)
                .HasForeignKey<CollaborativeQuest>(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Collabora__Quest__123EB7A3");
        });

        modelBuilder.Entity<ContentLibrary>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__ContentL__4F5E1825D762E643");

            entity.ToTable("ContentLibrary");

            entity.Property(e => e.ContentId).HasColumnName("Content_ID");
            entity.Property(e => e.ContentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Content_Type");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModuleId).HasColumnName("Module_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.ContentLibraries)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__ContentLi__Modul__778AC167");
        });

        modelBuilder.Entity<LearningPathProgress>(entity =>
        {
            entity.HasKey(e => e.ProgressId); // Define the primary key

            entity.HasOne(lp => lp.LearningPath)
                .WithMany()
                .HasForeignKey(lp => lp.PathId);

            entity.HasOne(lp => lp.Learner)
                .WithMany()
                .HasForeignKey(lp => lp.LearnerId);
        });

        // Other entity configurations...

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId);

            entity.Property(e => e.InstructorId).HasColumnName("Instructor_ID");
            entity.Property(e => e.InstructorName).HasColumnName("Instructor_Name").HasMaxLength(255);
            entity.Property(e => e.ExpertiseAreas).HasColumnName("Expertise_Areas").HasMaxLength(50);
            entity.Property(e => e.Qualifications).HasColumnName("Qualifications").HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserId"); // Map UserId property

            entity.HasOne(d => d.UserAccount)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull); // Configure the foreign key relationship
        });

        modelBuilder.Entity<InstructorEmail>(entity =>
        {
            entity.HasKey(e => e.InstructorEmailId);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasOne(d => d.Instructor)
                .WithMany(p => p.Emails)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });





        modelBuilder.Entity<Course>(entity =>
                            {
                                entity.HasKey(e => e.CourseId).HasName("PK__Courses__37E005FB8902CD41");

                                entity.Property(e => e.CourseId).HasColumnName("Course_ID");
                                entity.Property(e => e.CourseCreditHours).HasColumnName("Course_Credit_Hours");
                                entity.Property(e => e.CourseDescription)
                                    .HasMaxLength(100)
                                    .IsUnicode(false)
                                    .HasColumnName("Course_Description");
                                entity.Property(e => e.CourseTitle)
                                    .HasMaxLength(100)
                                    .IsUnicode(false)
                                    .HasColumnName("Course_Title");
                                entity.Property(e => e.DifficultyLevel)
                                    .HasMaxLength(50)
                                    .IsUnicode(false)
                                    .HasColumnName("Difficulty_Level");

                                entity.HasMany(d => d.Instructors).WithMany(p => p.Courses)
                                    .UsingEntity<Dictionary<string, object>>(
                                        "CoursesInstructor",
                                        r => r.HasOne<Instructor>().WithMany()
                                            .HasForeignKey("InstructorId")
                                            .OnDelete(DeleteBehavior.ClientSetNull)
                                            .HasConstraintName("FK__CoursesIn__Instr__47A6A41B"),
                                        l => l.HasOne<Course>().WithMany()
                                            .HasForeignKey("CourseId")
                                            .OnDelete(DeleteBehavior.ClientSetNull)
                                            .HasConstraintName("FK__CoursesIn__Cours__46B27FE2"),
                                        j =>
                                        {
                                            j.HasKey("CourseId", "InstructorId").HasName("PK__CoursesI__8A34BC5381155A32");
                                            j.ToTable("CoursesInstructor");
                                            j.IndexerProperty<int>("CourseId").HasColumnName("Course_ID");
                                            j.IndexerProperty<int>("InstructorId").HasColumnName("Instructor_ID");
                                        });

                                entity.HasMany(d => d.LearnersNavigation).WithMany(p => p.Courses)
                                    .UsingEntity<Dictionary<string, object>>(
                                        "LearnerCourse",
                                        r => r.HasOne<Learner>().WithMany()
                                            .HasForeignKey("LearnerId")
                                            .OnDelete(DeleteBehavior.ClientSetNull)
                                            .HasConstraintName("FK__LearnerCo__Learn__55F4C372"),
                                        l => l.HasOne<Course>().WithMany()
                                            .HasForeignKey("CourseId")
                                            .OnDelete(DeleteBehavior.ClientSetNull)
                                            .HasConstraintName("FK__LearnerCo__Cours__55009F39"),
                                        j =>
                                        {
                                            j.HasKey("CourseId", "LearnerId").HasName("PK__LearnerC__D43E2284F7B269A0");
                                            j.ToTable("LearnerCourses");
                                            j.IndexerProperty<int>("CourseId").HasColumnName("Course_ID");
                                            j.IndexerProperty<int>("LearnerId").HasColumnName("Learner_ID");
                                        });
                            });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => new { e.LearnerId, e.CourseId }).HasName("PK__CourseEn__9E9C77A0138D9DDA");

            entity.ToTable("CourseEnrollment");

            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.CompletionDate).HasColumnName("Completion_Date");
            entity.Property(e => e.EnrollmentDate).HasColumnName("Enrollment_Date");
            entity.Property(e => e.EnrollmentStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Enrollment_Status");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__Cours__70DDC3D8");

            entity.HasOne(d => d.Learner).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__Learn__6FE99F9F");
        });

        modelBuilder.Entity<CourseLearningObjective>(entity =>
        {
            entity.HasKey(e => new { e.CourseId, e.LearningObjective }).HasName("PK__CourseLe__47FAD9E8B6A45399");

            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.LearningObjective)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.CourseLearningObjectives)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseLea__Cours__5812160E");
        });

        modelBuilder.Entity<CoursePrerequisite>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__CoursePr__37E005FBEF28DC3C");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("Course_ID");
            entity.Property(e => e.Prerequisite).IsUnicode(false);

            entity.HasOne(d => d.Course).WithOne(p => p.CoursePrerequisite)
                .HasForeignKey<CoursePrerequisite>(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoursePre__Cours__5535A963");
        });

        modelBuilder.Entity<DiscussionForum>(entity =>
        {
            entity.HasKey(e => e.ForumId).HasName("PK__Discussi__E49DF9138BA8B854");

            entity.Property(e => e.ForumId).HasColumnName("Forum_ID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.LastTimeActive)
                .HasColumnType("datetime")
                .HasColumnName("Last_Time_Active");
            entity.Property(e => e.ModuleId).HasColumnName("Module_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.DiscussionForums)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Discussio__Modul__7E37BEF6");
        });

        modelBuilder.Entity<DiscussionForumsLearner>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DiscussionForumsLearner");

            entity.Property(e => e.ForumId).HasColumnName("Forum_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");

            entity.HasOne(d => d.Forum).WithMany()
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK__Discussio__Forum__4D5F7D71");

            entity.HasOne(d => d.Learner).WithMany()
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Discussio__Learn__4E53A1AA");
        });

        modelBuilder.Entity<EmotionalFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Emotiona__CD3992F8B5D6F044");

            entity.ToTable("EmotionalFeedback");

            entity.Property(e => e.FeedbackId).HasColumnName("Feedback_ID");
            entity.Property(e => e.ActivityId).HasColumnName("Activity_ID");
            entity.Property(e => e.EmotionalState)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Emotional_State");
            entity.Property(e => e.FeedbackTime)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("Feedback_Time");
            entity.Property(e => e.InstructorId).HasColumnName("Instructor_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");

            entity.HasOne(d => d.Activity).WithMany(p => p.EmotionalFeedbacks)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__Emotional__Activ__5CA1C101");

            entity.HasOne(d => d.Instructor).WithMany(p => p.EmotionalFeedbacks)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Emotional__Instr__5D95E53A");

            entity.HasOne(d => d.Learner).WithMany(p => p.EmotionalFeedbacks)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Emotional__Learn__5BAD9CC8");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__DD4B9A8AFFF401BE");

            entity.ToTable("Instructor");

            entity.Property(e => e.InstructorId).HasColumnName("Instructor_ID");
            entity.Property(e => e.ExpertiseAreas)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Expertise_Areas");
            entity.Property(e => e.InstructorName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Instructor_Name");
            entity.Property(e => e.Qualifications)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InstructorEmail>(entity =>
        {
            entity.HasKey(e => new { e.InstructorId, e.Email }).HasName("PK__Instruct__97D68AD9EB79A6D2");

            entity.ToTable("InstructorEmail");

            entity.Property(e => e.InstructorId).HasColumnName("Instructor_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Instructor).WithMany(p => p.Emails)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Instructo__Instr__2BFE89A6");
        });

        modelBuilder.Entity<InteractionLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Interact__2D26E7AE7788A041");

            entity.Property(e => e.LogId).HasColumnName("Log_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.LogDuration).HasColumnName("Log_Duration");
            entity.Property(e => e.LogType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Log_Type");
            entity.Property(e => e.TimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("Time_Stamp");

            entity.HasOne(d => d.Learner).WithMany(p => p.InteractionLogs)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Interacti__Learn__628FA481");
        });

        modelBuilder.Entity<Leaderboard>(entity =>
        {
            entity.HasKey(e => new { e.CourseId, e.BoardId }).HasName("PK__Leaderbo__36217AA16016EB39");

            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.BoardId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Board_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.Leaderboards)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Leaderboa__Cours__49C3F6B7");
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerId).HasName("PK__Learner__3DE277FF83027DBD");

            entity.ToTable("Learner");

            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.BoardId).HasColumnName("Board_ID");
            entity.Property(e => e.CountryOfOrigin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Country_of_Origin");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.ExperienceLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Experience_Level");
            entity.Property(e => e.LearnerAge)
                .HasComputedColumnSql("(datepart(year,getdate())-datepart(year,[Learner_Birthday_Date]))", false)
                .HasColumnName("Learner_Age");
            entity.Property(e => e.LearnerBirthdayDate).HasColumnName("Learner_Birthday_Date");
            entity.Property(e => e.LearnerGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Learner_Gender");
            entity.Property(e => e.LearnerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Learner_Name");

            entity.HasOne(d => d.Course).WithMany(p => p.Learners)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Learner__Course___4CA06362");

            entity.HasOne(d => d.Leaderboard).WithMany(p => p.Learners)
                .HasForeignKey(d => new { d.CourseId, d.BoardId })
                .HasConstraintName("FK__Learner__4D94879B");

            entity.HasMany(d => d.Achievements).WithMany(p => p.Learners)
                .UsingEntity<Dictionary<string, object>>(
                    "LearnerAchievement",
                    r => r.HasOne<Achievement>().WithMany()
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerAc__Achie__339FAB6E"),
                    l => l.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerAc__Learn__32AB8735"),
                    j =>
                    {
                        j.HasKey("LearnerId", "AchievementId").HasName("PK__LearnerA__9F46573372849998");
                        j.ToTable("LearnerAchievements");
                        j.IndexerProperty<int>("LearnerId").HasColumnName("Learner_ID");
                        j.IndexerProperty<int>("AchievementId").HasColumnName("Achievement_ID");
                    });

            entity.HasMany(d => d.Surveys).WithMany(p => p.Learners)
                .UsingEntity<Dictionary<string, object>>(
                    "LearnerSurvey",
                    r => r.HasOne<Survey>().WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerSu__Surve__3864608B"),
                    l => l.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerSu__Learn__37703C52"),
                    j =>
                    {
                        j.HasKey("LearnerId", "SurveyId").HasName("PK__LearnerS__6B223884529ACB55");
                        j.ToTable("LearnerSurveys");
                        j.IndexerProperty<int>("LearnerId").HasColumnName("Learner_ID");
                        j.IndexerProperty<int>("SurveyId").HasColumnName("Survey_ID");
                    });
        });

        modelBuilder.Entity<LearnerAssessment>(entity =>
        {
            entity.HasKey(e => new { e.LearnerId, e.AssessmentId }).HasName("PK__LearnerA__0B51B62682D24FB9");

            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.AssessmentId).HasColumnName("Assessment_ID");
            entity.Property(e => e.Points).HasColumnName("points");

            entity.HasOne(d => d.Assessment).WithMany(p => p.LearnerAssessments)
                .HasForeignKey(d => d.AssessmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerAs__Asses__2FCF1A8A");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerAssessments)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerAs__Learn__2EDAF651");
        });


        modelBuilder.Entity<LearnerDiscussionForum>(entity =>
        {
            entity.HasKey(e => new { e.ForumId, e.LearnerId, e.Post }).HasName("PK__LearnerD__A8E701A6D0C1FC84");

            entity.Property(e => e.ForumId).HasColumnName("Forum_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.Post)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Forum).WithMany(p => p.LearnerDiscussionForums)
                .HasForeignKey(d => d.ForumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerDi__Forum__22751F6C");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerDiscussionForums)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerDi__Learn__236943A5");
        });

        // Other entity configurations...



        // Other entity configurations...



        modelBuilder.Entity<LearnerNotification>(entity =>
                {
                    entity.HasKey(e => new { e.LearnerId, e.NotificationId }).HasName("PK__LearnerN__752361F4410735BE");

                    entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
                    entity.Property(e => e.NotificationId).HasColumnName("Notification_ID");

                    entity.HasOne(d => d.Learner).WithMany(p => p.LearnerNotifications)
                        .HasForeignKey(d => d.LearnerId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerNo__Learn__3B40CD36");

                    entity.HasOne(d => d.Notification).WithMany(p => p.LearnerNotifications)
                        .HasForeignKey(d => d.NotificationId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LearnerNo__Notif__3C34F16F");
                });

        modelBuilder.Entity<LearnerQuest>(entity =>
        {
            entity.HasKey(e => new { e.QuestId, e.LearnerId }).HasName("PK__LearnerQ__8E4054E450C18CF5");

            entity.Property(e => e.QuestId).HasColumnName("Quest_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Completion_Status");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerQuests)
                .HasForeignKey(d => d.LearnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerQu__Learn__1F98B2C1");

            entity.HasOne(d => d.Quest).WithMany(p => p.LearnerQuests)
                .HasForeignKey(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LearnerQu__Quest__1EA48E88");
        });

        modelBuilder.Entity<LearnerSkill>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.LearnerSkills)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Learner_Skills");

            entity.HasOne(d => d.Learner).WithMany()
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__LearnerSk__Learn__52593CB8");
        });

        modelBuilder.Entity<LearningActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Learning__393F5BA52270CBF1");

            entity.Property(e => e.ActivityId).HasColumnName("Activity_ID");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Activity_Type");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.DetailedInstructions)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Detailed_Instructions");
            entity.Property(e => e.LogId).HasColumnName("Log_ID");
            entity.Property(e => e.MaxPoints).HasColumnName("Max_Points");
            entity.Property(e => e.ModuleId).HasColumnName("Module_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.LearningActivities)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__LearningA__Cours__6C190EBB");

            entity.HasOne(d => d.Log).WithMany(p => p.LearningActivities)
                .HasForeignKey(d => d.LogId)
                .HasConstraintName("FK__LearningA__Log_I__6D0D32F4");

            entity.HasOne(d => d.Module).WithMany(p => p.LearningActivities)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__LearningA__Modul__6B24EA82");
        });

        modelBuilder.Entity<LearningGoal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__Learning__09AD12A277DD4F11");

            entity.Property(e => e.GoalId).HasColumnName("Goal_ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearningGoals)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__LearningG__Learn__01142BA1");
        });

        modelBuilder.Entity<LearningPath>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__Learning__12D3DFFB93EE5982");

            entity.ToTable("LearningPath");

            entity.Property(e => e.PathId)
                 .ValueGeneratedOnAdd()
                .HasColumnName("Path_ID");
            entity.Property(e => e.InstructorId).HasColumnName("Instructor_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.LearnerStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Learner_Status");
            entity.Property(e => e.PathDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Path_Description");
            entity.Property(e => e.Rules)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Instructor).WithMany(p => p.LearningPaths)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__LearningP__Instr__3F115E1A");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearningPaths)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__LearningP__Learn__40058253");

            entity.HasMany(d => d.PersonalizationProfiles).WithMany(p => p.Paths)
                .UsingEntity<Dictionary<string, object>>(
                    "PersonalizationProfilesLearningPath",
                    r => r.HasOne<PersonalizationProfile>().WithMany()
                        .HasForeignKey("PersonalizationProfileId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Personali__Perso__43D61337"),
                    l => l.HasOne<LearningPath>().WithMany()
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Personali__PathI__42E1EEFE"),
                    j =>
                    {
                        j.HasKey("PathId", "PersonalizationProfileId").HasName("PK__Personal__2A43BE03A9479754");
                        j.ToTable("PersonalizationProfilesLearningPaths");
                        j.IndexerProperty<int>("PathId").HasColumnName("PathID");
                        j.IndexerProperty<int>("PersonalizationProfileId").HasColumnName("PersonalizationProfileID");
                    });
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Modules__1DE4E028290D4F85");

            entity.Property(e => e.ModuleId).HasColumnName("Module_ID");
            entity.Property(e => e.ContentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Content_Type");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.LevelOfDifficulty)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Level_of_Difficulty");

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Modules__Course___5BE2A6F2");

            entity.HasMany(d => d.Activities).WithMany(p => p.Modules)
                .UsingEntity<Dictionary<string, object>>(
                    "ModulesLearningActivity",
                    r => r.HasOne<LearningActivity>().WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ModulesLe__Activ__4B7734FF"),
                    l => l.HasOne<Module>().WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ModulesLe__Modul__4A8310C6"),
                    j =>
                    {
                        j.HasKey("ModuleId", "ActivityId").HasName("PK__ModulesL__5E7715922B9F7755");
                        j.ToTable("ModulesLearningActivities");
                        j.IndexerProperty<int>("ModuleId").HasColumnName("Module_ID");
                        j.IndexerProperty<int>("ActivityId").HasColumnName("Activity_ID");
                    });
        });

        modelBuilder.Entity<ModulesLink>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.Link }).HasName("PK__ModulesL__86669DEEE65F3A99");

            entity.Property(e => e.ModuleId).HasColumnName("Module_ID");
            entity.Property(e => e.Link)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.ModulesLinks)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ModulesLi__Modul__656C112C");
        });

        modelBuilder.Entity<ModulesTargetTrait>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.TargetTrait }).HasName("PK__ModulesT__1A139C72C367DB66");

            entity.Property(e => e.ModuleId).HasColumnName("Module_ID");
            entity.Property(e => e.TargetTrait)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Target_Trait");

            entity.HasOne(d => d.Module).WithMany(p => p.ModulesTargetTraits)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ModulesTa__Modul__68487DD7");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__8C1160B583D31540");

            entity.Property(e => e.NotificationId).HasColumnName("Notification_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.MessageBody)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Message_Body");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.UrgencyLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Urgency_Level");

            entity.HasOne(d => d.Learner).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Notificat__Learn__7A672E12");
        });

        modelBuilder.Entity<PersonalizationProfile>(entity =>
        {
            entity.HasKey(e => e.PersonalizationProfileId).HasName("PK__Personal__724623AFA4037613");

            entity.Property(e => e.PersonalizationProfileId).HasColumnName("PersonalizationProfileID");
            entity.Property(e => e.CurrentEmotionalState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Current_Emotional_State");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.PathId).HasColumnName("PathID");
            entity.Property(e => e.PersonalityType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Personality_Type");
            entity.Property(e => e.PreferedContentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Prefered_content_type");

            entity.HasOne(d => d.Learner).WithMany(p => p.PersonalizationProfiles)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Personali__Learn__5070F446");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__Quests__6D9E739BABC867A3");

            entity.Property(e => e.QuestId).HasColumnName("Quest_ID");
            entity.Property(e => e.Criteria)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Difficulty_Level");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.RewardId).HasName("PK__Rewards__69FE4BD444A95930");

            entity.Property(e => e.RewardId).HasColumnName("Reward_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.QuestId).HasColumnName("Quest_ID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.Rewards)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Rewards__Learner__151B244E");

            entity.HasOne(d => d.Quest).WithMany(p => p.Rewards)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK__Rewards__Quest_I__160F4887");
        });

        modelBuilder.Entity<SkillMasteryQuest>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__SkillMas__6D9E739BF5EEE563");

            entity.ToTable("SkillMasteryQuest");

            entity.Property(e => e.QuestId)
                .ValueGeneratedNever()
                .HasColumnName("Quest_ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.SkillsToBeMastered)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Skills_To_Be_Mastered");

            entity.HasOne(d => d.Quest).WithOne(p => p.SkillMasteryQuest)
                .HasForeignKey<SkillMasteryQuest>(d => d.QuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SkillMast__Quest__0F624AF8");
        });

        modelBuilder.Entity<SkillProgression>(entity =>
        {
            entity.HasKey(e => e.SkillProgressionId).HasName("PK__SkillPro__50CEF27729A56E3F");

            entity.ToTable("SkillProgression");

            entity.Property(e => e.SkillProgressionId).HasColumnName("Skill_Progression_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.ProficiencyLevel).HasColumnName("Proficiency_Level");

            entity.HasOne(d => d.Learner).WithMany(p => p.SkillProgressions)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__SkillProg__Learn__18EBB532");
        });

        modelBuilder.Entity<SkillProgressionChallengingTask>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ChallengingTask)
                .HasColumnType("text")
                .HasColumnName("Challenging_Task");
            entity.Property(e => e.SkillProgressionId).HasColumnName("Skill_Progression_ID");

            entity.HasOne(d => d.SkillProgression).WithMany()
                .HasForeignKey(d => d.SkillProgressionId)
                .HasConstraintName("FK__SkillProg__Skill__1AD3FDA4");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.SurveyId).HasName("PK__Surveys__6C04F7B49B00D26D");

            entity.Property(e => e.SurveyId).HasColumnName("Survey_ID");
            entity.Property(e => e.LearnerId).HasColumnName("Learner_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.SurveysNavigation)
                .HasForeignKey(d => d.LearnerId)
                .HasConstraintName("FK__Surveys__Learner__03F0984C");
        });

        modelBuilder.Entity<SurveysQuestion>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.Question }).HasName("PK__SurveysQ__EAB770122A788E1D");

            entity.Property(e => e.SurveyId).HasColumnName("Survey_ID");
            entity.Property(e => e.Question)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveysQuestions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SurveysQu__Surve__06CD04F7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}