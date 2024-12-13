using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Quest
{
    public int QuestId { get; set; }

    public string? Title { get; set; }

    public string? DifficultyLevel { get; set; }

    public string? Criteria { get; set; }

    public virtual CollaborativeQuest? CollaborativeQuest { get; set; }

    public virtual ICollection<LearnerQuest> LearnerQuests { get; set; } = new List<LearnerQuest>();

    public virtual ICollection<Reward> Rewards { get; set; } = new List<Reward>();

    public virtual SkillMasteryQuest? SkillMasteryQuest { get; set; }
}
