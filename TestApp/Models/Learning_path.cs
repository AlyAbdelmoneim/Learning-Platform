using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Learning_path
{
    public int pathID { get; set; }

    public int? LearnerID { get; set; }

    public int? ProfileID { get; set; }

    public string? completion_status { get; set; }

    public string? custom_content { get; set; }

    public string? adaptive_rules { get; set; }

    public virtual ICollection<Pathreview> Pathreviews { get; set; } = new List<Pathreview>();

    public virtual PersonalizationProfile? PersonalizationProfile { get; set; }
}
