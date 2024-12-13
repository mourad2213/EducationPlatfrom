using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class DiscussionForum
{
    public int ForumId { get; set; }

    public int? ModuleId { get; set; }

    public DateTime? LastTimeActive { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<LearnerDiscussionForum> LearnerDiscussionForums { get; set; } = new List<LearnerDiscussionForum>();

    public virtual Module? Module { get; set; }
}
