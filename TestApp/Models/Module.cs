using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Module
{
    public int ModuleID { get; set; }

    public int CourseID { get; set; }

    public string? Title { get; set; }

    public string? difficulty { get; set; }

    public string? contentURL { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<ContentLibrary> ContentLibraries { get; set; } = new List<ContentLibrary>();

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Discussion_forum> Discussion_forums { get; set; } = new List<Discussion_forum>();

    public virtual ICollection<Learning_activity> Learning_activities { get; set; } = new List<Learning_activity>();

    public virtual ICollection<ModuleContent> ModuleContents { get; set; } = new List<ModuleContent>();

    public virtual ICollection<Target_trait> Target_traits { get; set; } = new List<Target_trait>();
}
