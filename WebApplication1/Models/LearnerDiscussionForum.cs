using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearnerDiscussionForum
{
    public int ForumId { get; set; }

    public int LearnerId { get; set; }

    public string Post { get; set; } = null!;

    public virtual DiscussionForum Forum { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
