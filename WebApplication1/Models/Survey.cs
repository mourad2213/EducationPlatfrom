using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Survey
{
    public int SurveyId { get; set; }

    public string? Title { get; set; }

    public int? LearnerId { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual ICollection<SurveysQuestion> SurveysQuestions { get; set; } = new List<SurveysQuestion>();

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
