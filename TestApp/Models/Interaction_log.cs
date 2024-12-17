using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Interaction_log
{
    public int LogID { get; set; }

    public int? activity_ID { get; set; }

    public int? LearnerID { get; set; }

    public int? Duration { get; set; }

    public DateTime? interaction_Timestamp { get; set; }

    public string? action_type { get; set; }

    public virtual Learner? Learner { get; set; }

    public virtual Learning_activity? activity { get; set; }
}
