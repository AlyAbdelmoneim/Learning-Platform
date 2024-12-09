using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class LearnersCollaboration
{
    public int LearnerID { get; set; }

    public int QuestID { get; set; }

    public string? completion_status { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Collaborative Quest { get; set; } = null!;
}
