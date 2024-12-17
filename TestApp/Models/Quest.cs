using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Quest
{
    public int QuestID { get; set; }

    public string? difficulty_level { get; set; }

    public string? criteria { get; set; }

    public string? quest_description { get; set; }

    public string? title { get; set; }

    public virtual Collaborative? Collaborative { get; set; }

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();

    public virtual ICollection<Skill_Mastery> Skill_Masteries { get; set; } = new List<Skill_Mastery>();
}
