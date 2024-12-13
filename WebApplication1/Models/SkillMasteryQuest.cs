using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class SkillMasteryQuest
{
    public int QuestId { get; set; }

    public string? Description { get; set; }

    public string? SkillsToBeMastered { get; set; }

    public virtual Quest Quest { get; set; } = null!;
}
