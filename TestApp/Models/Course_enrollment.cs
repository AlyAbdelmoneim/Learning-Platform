using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Course_enrollment
{
    public int EnrollmentID { get; set; }

    public int? CourseID { get; set; }

    public int? LearnerID { get; set; }

    public DateOnly? completion_date { get; set; }

    public DateOnly? enrollment_date { get; set; }

    public string? enrollment_status { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Learner? Learner { get; set; }
}
