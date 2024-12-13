using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string? MessageBody { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? UrgencyLevel { get; set; }

    public int? LearnerId { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual ICollection<LearnerNotification> LearnerNotifications { get; set; } = new List<LearnerNotification>();
}
