using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Survey
{
    public int ID { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>();

    public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();
}
