using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class SkillProgression
{
    public int ID { get; set; }

    public string? proficiency_level { get; set; }

    public int? LearnerID { get; set; }

    public string? skill_name { get; set; }

    public DateTime? skillProgression_timestamp { get; set; }

    public virtual Skill? Skill { get; set; }
}
