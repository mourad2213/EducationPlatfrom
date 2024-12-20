using System;

namespace WebApplication1.Models
{
    public partial class LearnerDiscussionForum
    {
        public int ForumId { get; set; }
        public int LearnerId { get; set; }
        public string Post { get; set; }

        public virtual DiscussionForum Forum { get; set; }
        public virtual Learner Learner { get; set; }
    }
}
