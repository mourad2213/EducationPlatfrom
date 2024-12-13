using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class SurveysQuestion
{
    public int SurveyId { get; set; }

    public string Question { get; set; } = null!;

    public virtual Survey Survey { get; set; } = null!;
}
