using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Skill_Mastery
{
    public int QuestID { get; set; }

    public string skill { get; set; } = null!;

    public virtual ICollection<LearnersMastery> LearnersMasteries { get; set; } = new List<LearnersMastery>();

    public virtual Quest Quest { get; set; } = null!;
}
