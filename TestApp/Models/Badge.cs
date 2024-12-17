using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Badge
{
    public int BadgeID { get; set; }

    public string? title { get; set; }

    public string? badge_description { get; set; }

    public string? criteria { get; set; }

    public int? points { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
