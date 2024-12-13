using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Reward
{
    public int RewardId { get; set; }

    public int? RewardValue { get; set; }

    public string? Type { get; set; }

    public int? LearnerId { get; set; }

    public int? QuestId { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual Quest? Quest { get; set; }
}
