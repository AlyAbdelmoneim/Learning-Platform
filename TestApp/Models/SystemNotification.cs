using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class SystemNotification
{
    public int ID { get; set; }

    public DateTime? notification_timestamp { get; set; }

    public string? notification_message { get; set; }

    public string? urgency_level { get; set; }

    public bool? ReadStatus { get; set; }

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
