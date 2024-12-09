using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Target_trait
{
    public int ModuleID { get; set; }

    public int CourseID { get; set; }

    public string Trait { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
