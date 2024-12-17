using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Takenassessment
{
    public int AssessmentID { get; set; }

    public int LearnerID { get; set; }

    public int? scoredPoint { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
