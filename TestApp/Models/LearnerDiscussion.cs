using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class LearnerDiscussion
{
    public int ForumID { get; set; }

    public int LearnerID { get; set; }

    public string? Post { get; set; }

    public DateTime discussion_time { get; set; }

    public virtual Discussion_forum Forum { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
