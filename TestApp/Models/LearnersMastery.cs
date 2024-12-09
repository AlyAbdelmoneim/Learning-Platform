using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class LearnersMastery
{
    public int LearnerID { get; set; }

    public int QuestID { get; set; }

    public string skill { get; set; } = null!;

    public string? completion_status { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Skill_Mastery Skill_Mastery { get; set; } = null!;
}
