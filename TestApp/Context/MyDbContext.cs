using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<Collaborative> Collaboratives { get; set; }

    public virtual DbSet<ContentLibrary> ContentLibraries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Course_enrollment> Course_enrollments { get; set; }

    public virtual DbSet<Discussion_forum> Discussion_forums { get; set; }

    public virtual DbSet<Emotional_feedback> Emotional_feedbacks { get; set; }

    public virtual DbSet<Emotionalfeedback_review> Emotionalfeedback_reviews { get; set; }

    public virtual DbSet<FilledSurvey> FilledSurveys { get; set; }

    public virtual DbSet<HealthCondition> HealthConditions { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Interaction_log> Interaction_logs { get; set; }

    public virtual DbSet<Leaderboard> Leaderboards { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<LearnerDiscussion> LearnerDiscussions { get; set; }

    public virtual DbSet<LearnersCollaboration> LearnersCollaborations { get; set; }

    public virtual DbSet<LearnersMastery> LearnersMasteries { get; set; }

    public virtual DbSet<LearningPreference> LearningPreferences { get; set; }

    public virtual DbSet<Learning_activity> Learning_activities { get; set; }

    public virtual DbSet<Learning_goal> Learning_goals { get; set; }

    public virtual DbSet<Learning_path> Learning_paths { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<ModuleContent> ModuleContents { get; set; }

    public virtual DbSet<Pathreview> Pathreviews { get; set; }

    public virtual DbSet<PersonalizationProfile> PersonalizationProfiles { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<QuestReward> QuestRewards { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillProgression> SkillProgressions { get; set; }

    public virtual DbSet<Skill_Mastery> Skill_Masteries { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }

    public virtual DbSet<SystemNotification> SystemNotifications { get; set; }

    public virtual DbSet<Takenassessment> Takenassessments { get; set; }

    public virtual DbSet<Target_trait> Target_traits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ProjectDatabase4;User Id=SA;Password=Password_123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementID).HasName("PK__Achievem__276330E023544A9B");

            entity.ToTable("Achievement");

            entity.HasIndex(e => e.BadgeID, "IX_Achievement_BadgeID");

            entity.HasIndex(e => e.LearnerID, "IX_Achievement_LearnerID");

            entity.Property(e => e.achievement_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.achievement_type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Badge).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.BadgeID)
                .HasConstraintName("FK__Achieveme__Badge__0B91BA14");

            entity.HasOne(d => d.Learner).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Achieveme__Learn__0A9D95DB");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminID).HasName("PK__Admin__719FE4E8141F71F8");

            entity.ToTable("Admin");

            entity.Property(e => e.adminPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.first_name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.last_name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Assessme__3214EC276EE946BA");

            entity.HasIndex(e => new { e.ModuleID, e.CourseID }, "IX_Assessments_ModuleID_CourseID");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.assessment_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.assessment_type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.criteria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Assessments)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Assessments__45F365D3");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeID).HasName("PK__Badge__1918237CC4C7E7BA");

            entity.ToTable("Badge");

            entity.Property(e => e.BadgeID).ValueGeneratedNever();
            entity.Property(e => e.badge_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.criteria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Collaborative>(entity =>
        {
            entity.HasKey(e => e.QuestID).HasName("PK__Collabor__B6619ACB049BF137");

            entity.ToTable("Collaborative");

            entity.Property(e => e.QuestID).ValueGeneratedNever();

            entity.HasOne(d => d.Quest).WithOne(p => p.Collaborative)
                .HasForeignKey<Collaborative>(d => d.QuestID)
                .HasConstraintName("FK__Collabora__Quest__151B244E");
        });

        modelBuilder.Entity<ContentLibrary>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__ContentL__3214EC27EDA576BC");

            entity.ToTable("ContentLibrary");

            entity.HasIndex(e => new { e.ModuleID, e.CourseID }, "IX_ContentLibrary_ModuleID_CourseID");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.content_URL)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.library_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.library_type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.metadata)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.ContentLibraries)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ContentLibrary__4316F928");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseID).HasName("PK__Course__C92D7187858F7C67");

            entity.ToTable("Course");

            entity.Property(e => e.CourseID).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.course_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.difficulty_level)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.learning_objective)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Courses).WithMany(p => p.Prereqs)
                .UsingEntity<Dictionary<string, object>>(
                    "CoursePrerequisite",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseID")
                        .HasConstraintName("FK__CoursePre__Cours__35BCFE0A"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("Prereq")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Prere__36B12243"),
                    j =>
                    {
                        j.HasKey("CourseID", "Prereq").HasName("PK__CoursePr__F8693C2C7CB310D2");
                        j.ToTable("CoursePrerequisite");
                        j.HasIndex(new[] { "Prereq" }, "IX_CoursePrerequisite_Prereq");
                    });

            entity.HasMany(d => d.Prereqs).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CoursePrerequisite",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("Prereq")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Prere__36B12243"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseID")
                        .HasConstraintName("FK__CoursePre__Cours__35BCFE0A"),
                    j =>
                    {
                        j.HasKey("CourseID", "Prereq").HasName("PK__CoursePr__F8693C2C7CB310D2");
                        j.ToTable("CoursePrerequisite");
                        j.HasIndex(new[] { "Prereq" }, "IX_CoursePrerequisite_Prereq");
                    });
        });

        modelBuilder.Entity<Course_enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentID).HasName("PK__Course_e__7F6877FB4136652D");

            entity.ToTable("Course_enrollment");

            entity.HasIndex(e => e.CourseID, "IX_Course_enrollment_CourseID");

            entity.HasIndex(e => e.LearnerID, "IX_Course_enrollment_LearnerID");

            entity.Property(e => e.enrollment_status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Course_enrollments)
                .HasForeignKey(d => d.CourseID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Course_en__Cours__6383C8BA");

            entity.HasOne(d => d.Learner).WithMany(p => p.Course_enrollments)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Course_en__Learn__6477ECF3");
        });

        modelBuilder.Entity<Discussion_forum>(entity =>
        {
            entity.HasKey(e => e.forumID).HasName("PK__Discussi__BBA7A44099226C3B");

            entity.ToTable("Discussion_forum");

            entity.HasIndex(e => new { e.ModuleID, e.CourseID }, "IX_Discussion_forum_ModuleID_CourseID");

            entity.Property(e => e.forum_description).IsUnicode(false);
            entity.Property(e => e.forum_timestamp).HasColumnType("datetime");
            entity.Property(e => e.title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Discussion_forums)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Discussion_forum__1F98B2C1");
        });

        modelBuilder.Entity<Emotional_feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackID).HasName("PK__Emotiona__6A4BEDF63FB36D75");

            entity.ToTable("Emotional_feedback");

            entity.HasIndex(e => e.LearnerID, "IX_Emotional_feedback_LearnerID");

            entity.HasIndex(e => e.activityID, "IX_Emotional_feedback_activityID");

            entity.Property(e => e.emotional_state)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.feedback_timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Learner).WithMany(p => p.Emotional_feedbacks)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Emotional__Learn__534D60F1");

            entity.HasOne(d => d.activity).WithMany(p => p.Emotional_feedbacks)
                .HasForeignKey(d => d.activityID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Emotional__activ__5441852A");
        });

        modelBuilder.Entity<Emotionalfeedback_review>(entity =>
        {
            entity.HasKey(e => new { e.FeedbackID, e.InstructorID }).HasName("PK__Emotiona__C39BFD41B8907463");

            entity.ToTable("Emotionalfeedback_review");

            entity.HasIndex(e => e.InstructorID, "IX_Emotionalfeedback_review_InstructorID");

            entity.Property(e => e.review)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Feedback).WithMany(p => p.Emotionalfeedback_reviews)
                .HasForeignKey(d => d.FeedbackID)
                .HasConstraintName("FK__Emotional__Feedb__5FB337D6");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Emotionalfeedback_reviews)
                .HasForeignKey(d => d.InstructorID)
                .HasConstraintName("FK__Emotional__Instr__60A75C0F");
        });

        modelBuilder.Entity<FilledSurvey>(entity =>
        {
            entity.HasKey(e => new { e.SurveyID, e.LearnerID }).HasName("PK__FilledSu__1332A052291DD5A1");

            entity.ToTable("FilledSurvey");

            entity.HasIndex(e => e.LearnerID, "IX_FilledSurvey_LearnerID");

            entity.Property(e => e.Answer)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__FilledSur__Learn__7D439ABD");

            entity.HasOne(d => d.Survey).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => d.SurveyID)
                .HasConstraintName("FK__FilledSur__Surve__7C4F7684");
        });

        modelBuilder.Entity<HealthCondition>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.ProfileID, e.condition }).HasName("PK__HealthCo__930320B04AEBAF0D");

            entity.ToTable("HealthCondition");

            entity.Property(e => e.condition)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.HealthConditions)
                .HasForeignKey(d => new { d.LearnerID, d.ProfileID })
                .HasConstraintName("FK__HealthCondition__30F848ED");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorID).HasName("PK__Instruct__9D010B7BBD5A31A8");

            entity.ToTable("Instructor");

            entity.Property(e => e.InstructorID).ValueGeneratedNever();
            entity.Property(e => e.adminPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.expertise_area)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.instructor_name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.latest_qualification)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Courses).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "Teach",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseID")
                        .HasConstraintName("FK__Teaches__CourseI__68487DD7"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorID")
                        .HasConstraintName("FK__Teaches__Instruc__6754599E"),
                    j =>
                    {
                        j.HasKey("InstructorID", "CourseID").HasName("PK__Teaches__F193DC63FFD0DBA8");
                        j.ToTable("Teaches");
                        j.HasIndex(new[] { "CourseID" }, "IX_Teaches_CourseID");
                    });
        });

        modelBuilder.Entity<Interaction_log>(entity =>
        {
            entity.HasKey(e => e.LogID).HasName("PK__Interact__5E5499A85009EA78");

            entity.ToTable("Interaction_log");

            entity.HasIndex(e => e.LearnerID, "IX_Interaction_log_LearnerID");

            entity.HasIndex(e => e.activity_ID, "IX_Interaction_log_activity_ID");

            entity.Property(e => e.LogID).ValueGeneratedNever();
            entity.Property(e => e.action_type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.interaction_Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Learner).WithMany(p => p.Interaction_logs)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Interacti__Learn__5070F446");

            entity.HasOne(d => d.activity).WithMany(p => p.Interaction_logs)
                .HasForeignKey(d => d.activity_ID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Interacti__activ__4F7CD00D");
        });

        modelBuilder.Entity<Leaderboard>(entity =>
        {
            entity.HasKey(e => e.BoardID).HasName("PK__Leaderbo__F9646BD2F416643D");

            entity.ToTable("Leaderboard");

            entity.Property(e => e.BoardID).ValueGeneratedNever();
            entity.Property(e => e.season)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerID).HasName("PK__Learner__67ABFCFAC184F3EB");

            entity.ToTable("Learner");

            entity.Property(e => e.LearnerID).ValueGeneratedNever();
            entity.Property(e => e.adminPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.cultural_background)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.first_name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.last_name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LearnerDiscussion>(entity =>
        {
            entity.HasKey(e => new { e.ForumID, e.LearnerID, e.discussion_time }).HasName("PK__LearnerD__91B2B1CB65886A96");

            entity.ToTable("LearnerDiscussion");

            entity.HasIndex(e => e.LearnerID, "IX_LearnerDiscussion_LearnerID");

            entity.Property(e => e.discussion_time).HasColumnType("datetime");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Forum).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.ForumID)
                .HasConstraintName("FK__LearnerDi__Forum__22751F6C");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearnerDi__Learn__236943A5");
        });

        modelBuilder.Entity<LearnersCollaboration>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.QuestID }).HasName("PK__Learners__CCCDE556F90C4332");

            entity.ToTable("LearnersCollaboration");

            entity.HasIndex(e => e.QuestID, "IX_LearnersCollaboration_QuestID");

            entity.Property(e => e.completion_status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearnersC__Learn__17F790F9");

            entity.HasOne(d => d.Quest).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.QuestID)
                .HasConstraintName("FK__LearnersC__Quest__18EBB532");
        });

        modelBuilder.Entity<LearnersMastery>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.QuestID, e.skill }).HasName("PK__Learners__36F2E77357749B39");

            entity.ToTable("LearnersMastery");

            entity.HasIndex(e => new { e.QuestID, e.skill }, "IX_LearnersMastery_QuestID_skill");

            entity.Property(e => e.skill)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.completion_status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnersMasteries)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearnersM__Learn__1BC821DD");

            entity.HasOne(d => d.Skill_Mastery).WithMany(p => p.LearnersMasteries)
                .HasForeignKey(d => new { d.QuestID, d.skill })
                .HasConstraintName("FK__LearnersMastery__1CBC4616");
        });

        modelBuilder.Entity<LearningPreference>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.preference }).HasName("PK__Learning__6032E158D25CD66C");

            entity.ToTable("LearningPreference");

            entity.Property(e => e.preference)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearningPreferences)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearningP__Learn__2B3F6F97");
        });

        modelBuilder.Entity<Learning_activity>(entity =>
        {
            entity.HasKey(e => e.ActivityID).HasName("PK__Learning__45F4A7F166D8612F");

            entity.HasIndex(e => new { e.ModuleID, e.CourseID }, "IX_Learning_activities_ModuleID_CourseID");

            entity.Property(e => e.activity_type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.instruction_details).IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Learning_activities)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Learning_activit__4CA06362");
        });

        modelBuilder.Entity<Learning_goal>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Learning__3214EC270559B7BD");

            entity.ToTable("Learning_goal");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.goal_description).IsUnicode(false);
            entity.Property(e => e.goal_status).IsUnicode(false);

            entity.HasMany(d => d.Learners).WithMany(p => p.Goals)
                .UsingEntity<Dictionary<string, object>>(
                    "LearnersGoal",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerID")
                        .HasConstraintName("FK__LearnersG__Learn__74AE54BC"),
                    l => l.HasOne<Learning_goal>().WithMany()
                        .HasForeignKey("GoalID")
                        .HasConstraintName("FK__LearnersG__GoalI__73BA3083"),
                    j =>
                    {
                        j.HasKey("GoalID", "LearnerID").HasName("PK__Learners__3C3540FE7EB443B8");
                        j.ToTable("LearnersGoals");
                        j.HasIndex(new[] { "LearnerID" }, "IX_LearnersGoals_LearnerID");
                    });
        });

        modelBuilder.Entity<Learning_path>(entity =>
        {
            entity.HasKey(e => e.pathID).HasName("PK__Learning__BFB8200A6BAFEF07");

            entity.ToTable("Learning_path");

            entity.HasIndex(e => new { e.LearnerID, e.ProfileID }, "IX_Learning_path_LearnerID_ProfileID");

            entity.Property(e => e.adaptive_rules).IsUnicode(false);
            entity.Property(e => e.completion_status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.custom_content).IsUnicode(false);

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.Learning_paths)
                .HasForeignKey(d => new { d.LearnerID, d.ProfileID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Learning_path__571DF1D5");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => new { e.ModuleID, e.CourseID }).HasName("PK__Modules__47E6A09F434026F9");

            entity.HasIndex(e => e.CourseID, "IX_Modules_CourseID");

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.contentURL)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.difficulty)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CourseID)
                .HasConstraintName("FK__Modules__CourseI__3A81B327");
        });

        modelBuilder.Entity<ModuleContent>(entity =>
        {
            entity.HasKey(e => new { e.ModuleID, e.CourseID, e.content_type }).HasName("PK__ModuleCo__402E75DAB9D5EC61");

            entity.ToTable("ModuleContent");

            entity.Property(e => e.content_type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleContents)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .HasConstraintName("FK__ModuleContent__403A8C7D");
        });

        modelBuilder.Entity<Pathreview>(entity =>
        {
            entity.HasKey(e => new { e.InstructorID, e.PathID }).HasName("PK__Pathrevi__11D776B83E82DF0D");

            entity.ToTable("Pathreview");

            entity.HasIndex(e => e.PathID, "IX_Pathreview_PathID");

            entity.Property(e => e.review)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Instructor).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.InstructorID)
                .HasConstraintName("FK__Pathrevie__Instr__5BE2A6F2");

            entity.HasOne(d => d.Path).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.PathID)
                .HasConstraintName("FK__Pathrevie__PathI__5CD6CB2B");
        });

        modelBuilder.Entity<PersonalizationProfile>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.ProfileID }).HasName("PK__Personal__353B347287046E4B");

            entity.Property(e => e.Prefered_content_type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.emotional_state)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.personality_type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.PersonalizationProfiles)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Personali__Learn__2E1BDC42");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QuestID).HasName("PK__Quest__B6619ACB5F511237");

            entity.ToTable("Quest");

            entity.Property(e => e.criteria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.difficulty_level)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.quest_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<QuestReward>(entity =>
        {
            entity.HasKey(e => new { e.RewardID, e.QuestID, e.LearnerID }).HasName("PK__QuestRew__D251A7C966B04FEA");

            entity.ToTable("QuestReward");

            entity.HasIndex(e => e.LearnerID, "IX_QuestReward_LearnerID");

            entity.HasIndex(e => e.QuestID, "IX_QuestReward_QuestID");

            entity.Property(e => e.Time_earned).HasColumnType("datetime");

            entity.HasOne(d => d.Learner).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__QuestRewa__Learn__282DF8C2");

            entity.HasOne(d => d.Quest).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.QuestID)
                .HasConstraintName("FK__QuestRewa__Quest__2739D489");

            entity.HasOne(d => d.Reward).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.RewardID)
                .HasConstraintName("FK__QuestRewa__Rewar__2645B050");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => new { e.BoardID, e.LearnerID, e.CourseID }).HasName("PK__Ranking__C9D7F96CA16A33B7");

            entity.ToTable("Ranking");

            entity.HasIndex(e => e.CourseID, "IX_Ranking_CourseID");

            entity.HasIndex(e => e.LearnerID, "IX_Ranking_LearnerID");

            entity.HasOne(d => d.Board).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.BoardID)
                .HasConstraintName("FK__Ranking__BoardID__6D0D32F4");

            entity.HasOne(d => d.Course).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.CourseID)
                .HasConstraintName("FK__Ranking__CourseI__6EF57B66");

            entity.HasOne(d => d.Learner).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Ranking__Learner__6E01572D");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.RewardID).HasName("PK__Reward__8250159987128AA8");

            entity.ToTable("Reward");

            entity.Property(e => e.RewardID).ValueGeneratedNever();
            entity.Property(e => e.reward_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.reward_type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.skill }).HasName("PK__Skills__C45BDEA56FA2A2BB");

            entity.Property(e => e.skill)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.Skills)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Skills__LearnerI__286302EC");
        });

        modelBuilder.Entity<SkillProgression>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__SkillPro__3214EC274706C606");

            entity.ToTable("SkillProgression");

            entity.HasIndex(e => new { e.LearnerID, e.skill_name }, "IX_SkillProgression_LearnerID_skill_name");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.proficiency_level)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.skillProgression_timestamp).HasColumnType("datetime");
            entity.Property(e => e.skill_name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Skill).WithMany(p => p.SkillProgressions)
                .HasForeignKey(d => new { d.LearnerID, d.skill_name })
                .HasConstraintName("FK__SkillProgression__07C12930");
        });

        modelBuilder.Entity<Skill_Mastery>(entity =>
        {
            entity.HasKey(e => new { e.QuestID, e.skill }).HasName("PK__Skill_Ma__1591B894962226D6");

            entity.ToTable("Skill_Mastery");

            entity.Property(e => e.skill)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Quest).WithMany(p => p.Skill_Masteries)
                .HasForeignKey(d => d.QuestID)
                .HasConstraintName("FK__Skill_Mas__Quest__123EB7A3");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Survey__3214EC2788E69964");

            entity.ToTable("Survey");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SurveyQuestion>(entity =>
        {
            entity.HasKey(e => new { e.SurveyID, e.Question }).HasName("PK__SurveyQu__23FB983B0844FF36");

            entity.Property(e => e.Question)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestions)
                .HasForeignKey(d => d.SurveyID)
                .HasConstraintName("FK__SurveyQue__Surve__797309D9");
        });

        modelBuilder.Entity<SystemNotification>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__SystemNo__3214EC27F487F741");

            entity.ToTable("SystemNotification");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.notification_message).IsUnicode(false);
            entity.Property(e => e.notification_timestamp).HasColumnType("datetime");
            entity.Property(e => e.urgency_level)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Learners).WithMany(p => p.Notifications)
                .UsingEntity<Dictionary<string, object>>(
                    "ReceivedNotification",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerID")
                        .HasConstraintName("FK__ReceivedN__Learn__02FC7413"),
                    l => l.HasOne<SystemNotification>().WithMany()
                        .HasForeignKey("NotificationID")
                        .HasConstraintName("FK__ReceivedN__Notif__02084FDA"),
                    j =>
                    {
                        j.HasKey("NotificationID", "LearnerID").HasName("PK__Received__96B591FD57A0EC60");
                        j.ToTable("ReceivedNotification");
                        j.HasIndex(new[] { "LearnerID" }, "IX_ReceivedNotification_LearnerID");
                    });
        });

        modelBuilder.Entity<Takenassessment>(entity =>
        {
            entity.HasKey(e => new { e.AssessmentID, e.LearnerID }).HasName("PK__Takenass__8B5147F1A2F864E5");

            entity.ToTable("Takenassessment");

            entity.HasIndex(e => e.LearnerID, "IX_Takenassessment_LearnerID");

            entity.HasOne(d => d.Assessment).WithMany(p => p.Takenassessments)
                .HasForeignKey(d => d.AssessmentID)
                .HasConstraintName("FK__Takenasse__Asses__49C3F6B7");

            entity.HasOne(d => d.Learner).WithMany(p => p.Takenassessments)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Takenasse__Learn__48CFD27E");
        });

        modelBuilder.Entity<Target_trait>(entity =>
        {
            entity.HasKey(e => new { e.ModuleID, e.CourseID, e.Trait }).HasName("PK__Target_t__4E005E4C7809D2BA");

            entity.Property(e => e.Trait)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Target_traits)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .HasConstraintName("FK__Target_traits__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
