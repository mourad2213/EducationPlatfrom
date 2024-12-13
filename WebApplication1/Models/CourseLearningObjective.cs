using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class CourseLearningObjective
{
    public int CourseId { get; set; }

    public string LearningObjective { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
