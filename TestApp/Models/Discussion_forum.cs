using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Discussion_forum
{
    public int forumID { get; set; }

    public int? ModuleID { get; set; }

    public int? CourseID { get; set; }

    public string? title { get; set; }

    public TimeOnly? last_active { get; set; }

    public DateTime? forum_timestamp { get; set; }

    public string? forum_description { get; set; }

    public virtual ICollection<LearnerDiscussion> LearnerDiscussions { get; set; } = new List<LearnerDiscussion>();

    public virtual Module? Module { get; set; }
}
