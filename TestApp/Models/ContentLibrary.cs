using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class ContentLibrary
{
    public int ID { get; set; }

    public int? ModuleID { get; set; }

    public int? CourseID { get; set; }

    public string? Title { get; set; }

    public string? library_description { get; set; }

    public string? metadata { get; set; }

    public string? library_type { get; set; }

    public string? content_URL { get; set; }

    public virtual Module? Module { get; set; }
}
