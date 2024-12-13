using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class CollaborativeQuest
{
    public int QuestId { get; set; }

    public DateOnly? Deadline { get; set; }

    public int? MaxParticipants { get; set; }

    public virtual Quest Quest { get; set; } = null!;
}
