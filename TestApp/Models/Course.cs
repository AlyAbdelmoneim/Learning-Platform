using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Course
{
    public int CourseID { get; set; }

    public string? Title { get; set; }

    public string? learning_objective { get; set; }

    public int? credit_points { get; set; }

    public string? difficulty_level { get; set; }

    public string? course_description { get; set; }

    public virtual ICollection<Course_enrollment> Course_enrollments { get; set; } = new List<Course_enrollment>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Course> Prereqs { get; set; } = new List<Course>();
}
