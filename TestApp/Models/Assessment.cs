using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Assessment
{
    public int ID { get; set; }

    public int? ModuleID { get; set; }

    public int? CourseID { get; set; }

    public string? assessment_type { get; set; }

    public int? total_marks { get; set; }

    public int? passing_marks { get; set; }

    public string? criteria { get; set; }

    public int? weightage { get; set; }

    public string? assessment_description { get; set; }

    public string? title { get; set; }

    public virtual Module? Module { get; set; }

    public virtual ICollection<Takenassessment> Takenassessments { get; set; } = new List<Takenassessment>();
}
