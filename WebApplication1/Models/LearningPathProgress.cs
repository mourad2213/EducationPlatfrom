using System;

namespace WebApplication1.Models
{
    public class LearningPathProgress
    {
        public int ProgressId { get; set; }
        public int PathId { get; set; }
        public int LearnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ProgressPercentage { get; set; }

        public virtual LearningPath LearningPath { get; set; }
        public virtual Learner Learner { get; set; }
    }
}
