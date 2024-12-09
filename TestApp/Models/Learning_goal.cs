using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Learning_goal
{
    public int ID { get; set; }

    public string? goal_status { get; set; }

    public DateOnly? deadline { get; set; }

    public string? goal_description { get; set; }

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
