using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class SurveyQuestion
{
    public int SurveyID { get; set; }

    public string Question { get; set; } = null!;

    public virtual Survey Survey { get; set; } = null!;
}
