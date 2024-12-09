using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class ModuleContent
{
    public int ModuleID { get; set; }

    public int CourseID { get; set; }

    public string content_type { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
