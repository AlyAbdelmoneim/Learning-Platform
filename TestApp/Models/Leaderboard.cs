using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Leaderboard
{
    public int BoardID { get; set; }

    public string? season { get; set; }

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();
}
