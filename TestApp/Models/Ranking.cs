using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Ranking
{
    public int BoardID { get; set; }

    public int LearnerID { get; set; }

    public int CourseID { get; set; }

    public int? rankNum { get; set; }

    public int? total_points { get; set; }

    public virtual Leaderboard Board { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
