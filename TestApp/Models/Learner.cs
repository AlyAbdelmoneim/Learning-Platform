using System;
using System.Collections.Generic;

namespace TestApp.Models;

public partial class Learner
{
    public int LearnerID { get; set; }

    public string? first_name { get; set; }

    public string? last_name { get; set; }

    public string? gender { get; set; }

    public DateOnly? birth_date { get; set; }

    public string? country { get; set; }

    public string? cultural_background { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Course_enrollment> Course_enrollments { get; set; } = new List<Course_enrollment>();

    public virtual ICollection<Emotional_feedback> Emotional_feedbacks { get; set; } = new List<Emotional_feedback>();

    public virtual ICollection<FilledSurvey> FilledSurveys { get; set; } = new List<FilledSurvey>();

    public virtual ICollection<Interaction_log> Interaction_logs { get; set; } = new List<Interaction_log>();

    public virtual ICollection<LearnerDiscussion> LearnerDiscussions { get; set; } = new List<LearnerDiscussion>();

    public virtual ICollection<LearnersCollaboration> LearnersCollaborations { get; set; } = new List<LearnersCollaboration>();

    public virtual ICollection<LearnersMastery> LearnersMasteries { get; set; } = new List<LearnersMastery>();

    public virtual ICollection<LearningPreference> LearningPreferences { get; set; } = new List<LearningPreference>();

    public virtual ICollection<PersonalizationProfile> PersonalizationProfiles { get; set; } = new List<PersonalizationProfile>();

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<Takenassessment> Takenassessments { get; set; } = new List<Takenassessment>();

    public virtual ICollection<Learning_goal> Goals { get; set; } = new List<Learning_goal>();

    public virtual ICollection<SystemNotification> Notifications { get; set; } = new List<SystemNotification>();
}
