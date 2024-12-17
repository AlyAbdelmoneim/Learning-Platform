using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Reward
{
    public int RewardID { get; set; }

    public int? reward_value { get; set; }

    public string? reward_description { get; set; }

    public string? reward_type { get; set; }

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();
}
