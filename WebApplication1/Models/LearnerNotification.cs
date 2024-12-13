using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class LearnerNotification
{
    public int LearnerId { get; set; }

    public int NotificationId { get; set; }

    public bool? ReadStatus { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Notification Notification { get; set; } = null!;
}
