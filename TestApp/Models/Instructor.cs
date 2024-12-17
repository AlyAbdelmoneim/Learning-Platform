using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Instructor
{
    public int InstructorID { get; set; }

    public string? instructor_name { get; set; }

    public string? latest_qualification { get; set; }

    public string? expertise_area { get; set; }

    public string? email { get; set; }

    public string? adminPassword { get; set; }

    public virtual ICollection<Emotionalfeedback_review> Emotionalfeedback_reviews { get; set; } = new List<Emotionalfeedback_review>();

    public virtual ICollection<Pathreview> Pathreviews { get; set; } = new List<Pathreview>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();


}
