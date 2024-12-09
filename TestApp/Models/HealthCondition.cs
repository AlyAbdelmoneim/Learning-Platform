using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class HealthCondition
{
    public int LearnerID { get; set; }

    public int ProfileID { get; set; }

    public string condition { get; set; } = null!;

    public virtual PersonalizationProfile PersonalizationProfile { get; set; } = null!;
}
