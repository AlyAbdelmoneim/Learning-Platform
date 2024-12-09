using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class FilledSurvey
{
    public int SurveyID { get; set; }

    public int LearnerID { get; set; }

    public string? Answer { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Survey Survey { get; set; } = null!;
}
