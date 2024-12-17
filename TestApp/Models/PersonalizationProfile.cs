using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class PersonalizationProfile
{
    public int LearnerID { get; set; }

    public int ProfileID { get; set; }

    public string? Prefered_content_type { get; set; }

    public string? emotional_state { get; set; }

    public string? personality_type { get; set; }

    public virtual ICollection<HealthCondition> HealthConditions { get; set; } = new List<HealthCondition>();


    public virtual ICollection<Learning_path> Learning_paths { get; set; } = new List<Learning_path>();
}
