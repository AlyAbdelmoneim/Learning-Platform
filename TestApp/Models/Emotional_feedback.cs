using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Emotional_feedback
{
    public int FeedbackID { get; set; }

    public int? LearnerID { get; set; }

    public int? activityID { get; set; }

    public DateTime? feedback_timestamp { get; set; }

    public string? emotional_state { get; set; }

    public virtual ICollection<Emotionalfeedback_review> Emotionalfeedback_reviews { get; set; } = new List<Emotionalfeedback_review>();

    public virtual Learner? Learner { get; set; }

    public virtual Learning_activity? activity { get; set; }
}
