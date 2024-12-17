using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Emotionalfeedback_review
{
    public int FeedbackID { get; set; }

    public int InstructorID { get; set; }

    public string? review { get; set; }

    public virtual Emotional_feedback Feedback { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;
}
