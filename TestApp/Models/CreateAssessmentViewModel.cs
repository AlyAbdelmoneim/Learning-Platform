using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

public class CreateAssessmentViewModel
{
    public int CourseID { get; set; }
    public int ModuleID { get; set; }
    public string Title { get; set; }
    public string AssessmentType { get; set; }
    public double Weightage { get; set; }
    public string Description { get; set; }
    public int TotalMarks { get; set; }
    public int PassingMarks { get; set; }
    public IEnumerable<SelectListItem> Courses { get; set; }
    public IEnumerable<SelectListItem> Modules { get; set; }
}
