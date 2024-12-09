using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class LearningPreference
{
    public int LearnerID { get; set; }

    public string preference { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
