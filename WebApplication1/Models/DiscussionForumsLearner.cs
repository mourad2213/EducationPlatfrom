using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class DiscussionForumsLearner
{
    public int? ForumId { get; set; }

    public int? LearnerId { get; set; }

    public virtual DiscussionForum? Forum { get; set; }

    public virtual Learner? Learner { get; set; }
}
