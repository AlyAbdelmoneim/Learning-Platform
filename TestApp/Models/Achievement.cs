using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Achievement
{
    public int AchievementID { get; set; }

    public int? LearnerID { get; set; }

    public int? BadgeID { get; set; }

    public string? achievement_description { get; set; }

    public DateOnly? date_earned { get; set; }

    public string? achievement_type { get; set; }

    public virtual Badge? Badge { get; set; }

    public virtual Learner? Learner { get; set; }
}
