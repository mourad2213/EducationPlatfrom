using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class CoursePrerequisite
{
    public int CourseId { get; set; }

    public string? Prerequisite { get; set; }

    public virtual Course Course { get; set; } = null!;
}
