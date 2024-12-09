using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Learning_activity
{
    public int ActivityID { get; set; }

    public int? ModuleID { get; set; }

    public int? CourseID { get; set; }

    public string? activity_type { get; set; }

    public string? instruction_details { get; set; }

    public int? Max_points { get; set; }

    public virtual ICollection<Emotional_feedback> Emotional_feedbacks { get; set; } = new List<Emotional_feedback>();

    public virtual ICollection<Interaction_log> Interaction_logs { get; set; } = new List<Interaction_log>();

    public virtual Module? Module { get; set; }
}
