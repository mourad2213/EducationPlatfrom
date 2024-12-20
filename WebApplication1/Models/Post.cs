using System;

namespace WebApplication1.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int? ForumId { get; set; }
        public int? LearnerId { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual DiscussionForum? Forum { get; set; }
        public virtual Learner? Learner { get; set; }
    }
}
