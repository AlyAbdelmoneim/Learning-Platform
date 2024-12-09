using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Pathreview
{
    public int InstructorID { get; set; }

    public int PathID { get; set; }

    public string? review { get; set; }

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual Learning_path Path { get; set; } = null!;
}
