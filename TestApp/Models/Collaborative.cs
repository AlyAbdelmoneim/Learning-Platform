using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Collaborative
{
    public int QuestID { get; set; }

    public DateOnly? deadline { get; set; }

    public int? max_num_participants { get; set; }

    public virtual ICollection<LearnersCollaboration> LearnersCollaborations { get; set; } = new List<LearnersCollaboration>();

    public virtual Quest Quest { get; set; } = null!;
}
