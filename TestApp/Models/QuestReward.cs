using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class QuestReward
{
    public int RewardID { get; set; }

    public int QuestID { get; set; }

    public int LearnerID { get; set; }

    public DateTime? Time_earned { get; set; }

    public virtual Learner Learner { get; set; } = null!;

    public virtual Quest Quest { get; set; } = null!;

    public virtual Reward Reward { get; set; } = null!;
}
