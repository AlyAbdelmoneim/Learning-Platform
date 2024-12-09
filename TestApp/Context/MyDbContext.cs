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
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LearningManagementSystem;User Id=SA;Password=Password_123; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementID).HasName("PK__Achievem__276330E0F5DC5AA9");

            entity.ToTable("Achievement");

            entity.Property(e => e.achievement_description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.achievement_type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Badge).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.BadgeID)
                .HasConstraintName("FK__Achieveme__Badge__09A971A2");

            entity.HasOne(d => d.Learner).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Achieveme__Learn__08B54D69");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Assessme__3214EC27B9FE4898");

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
                .HasConstraintName("FK__Assessments__440B1D61");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeID).HasName("PK__Badge__1918237C26A9CC87");

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
            entity.HasKey(e => e.QuestID).HasName("PK__Collabor__B6619ACB20DBB131");

            entity.ToTable("Collaborative");

            entity.Property(e => e.QuestID).ValueGeneratedNever();

            entity.HasOne(d => d.Quest).WithOne(p => p.Collaborative)
                .HasForeignKey<Collaborative>(d => d.QuestID)
                .HasConstraintName("FK__Collabora__Quest__1332DBDC");
        });

        modelBuilder.Entity<ContentLibrary>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__ContentL__3214EC273715F8D5");

            entity.ToTable("ContentLibrary");

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
                .HasConstraintName("FK__ContentLibrary__412EB0B6");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseID).HasName("PK__Course__C92D7187CDA97941");

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
                        .HasConstraintName("FK__CoursePre__Cours__33D4B598"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("Prereq")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Prere__34C8D9D1"),
                    j =>
                    {
                        j.HasKey("CourseID", "Prereq").HasName("PK__CoursePr__F8693C2C251470D4");
                        j.ToTable("CoursePrerequisite");
                    });

            entity.HasMany(d => d.Prereqs).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CoursePrerequisite",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("Prereq")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursePre__Prere__34C8D9D1"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseID")
                        .HasConstraintName("FK__CoursePre__Cours__33D4B598"),
                    j =>
                    {
                        j.HasKey("CourseID", "Prereq").HasName("PK__CoursePr__F8693C2C251470D4");
                        j.ToTable("CoursePrerequisite");
                    });
        });

        modelBuilder.Entity<Course_enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentID).HasName("PK__Course_e__7F6877FBFFBAEACC");

            entity.ToTable("Course_enrollment");

            entity.Property(e => e.enrollment_status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Course_enrollments)
                .HasForeignKey(d => d.CourseID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Course_en__Cours__619B8048");

            entity.HasOne(d => d.Learner).WithMany(p => p.Course_enrollments)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Course_en__Learn__628FA481");
        });

        modelBuilder.Entity<Discussion_forum>(entity =>
        {
            entity.HasKey(e => e.forumID).HasName("PK__Discussi__BBA7A440E4466EDD");

            entity.ToTable("Discussion_forum");

            entity.Property(e => e.forum_description).IsUnicode(false);
            entity.Property(e => e.forum_timestamp).HasColumnType("datetime");
            entity.Property(e => e.title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Discussion_forums)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Discussion_forum__1DB06A4F");
        });

        modelBuilder.Entity<Emotional_feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackID).HasName("PK__Emotiona__6A4BEDF69D542BC6");

            entity.ToTable("Emotional_feedback");

            entity.Property(e => e.emotional_state)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.feedback_timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Learner).WithMany(p => p.Emotional_feedbacks)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Emotional__Learn__5165187F");

            entity.HasOne(d => d.activity).WithMany(p => p.Emotional_feedbacks)
                .HasForeignKey(d => d.activityID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Emotional__activ__52593CB8");
        });

        modelBuilder.Entity<Emotionalfeedback_review>(entity =>
        {
            entity.HasKey(e => new { e.FeedbackID, e.InstructorID }).HasName("PK__Emotiona__C39BFD41DA8CCAA6");

            entity.ToTable("Emotionalfeedback_review");

            entity.Property(e => e.review)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Feedback).WithMany(p => p.Emotionalfeedback_reviews)
                .HasForeignKey(d => d.FeedbackID)
                .HasConstraintName("FK__Emotional__Feedb__5DCAEF64");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Emotionalfeedback_reviews)
                .HasForeignKey(d => d.InstructorID)
                .HasConstraintName("FK__Emotional__Instr__5EBF139D");
        });

        modelBuilder.Entity<FilledSurvey>(entity =>
        {
            entity.HasKey(e => new { e.SurveyID, e.LearnerID }).HasName("PK__FilledSu__1332A05218198A92");

            entity.ToTable("FilledSurvey");

            entity.Property(e => e.Answer)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__FilledSur__Learn__7B5B524B");

            entity.HasOne(d => d.Survey).WithMany(p => p.FilledSurveys)
                .HasForeignKey(d => d.SurveyID)
                .HasConstraintName("FK__FilledSur__Surve__7A672E12");
        });

        modelBuilder.Entity<HealthCondition>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.ProfileID, e.condition }).HasName("PK__HealthCo__930320B00193FA1A");

            entity.ToTable("HealthCondition");

            entity.Property(e => e.condition)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.HealthConditions)
                .HasForeignKey(d => new { d.LearnerID, d.ProfileID })
                .HasConstraintName("FK__HealthCondition__2F10007B");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorID).HasName("PK__Instruct__9D010B7BB78D4B94");

            entity.ToTable("Instructor");

            entity.Property(e => e.InstructorID).ValueGeneratedNever();
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
                        .HasConstraintName("FK__Teaches__CourseI__66603565"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorID")
                        .HasConstraintName("FK__Teaches__Instruc__656C112C"),
                    j =>
                    {
                        j.HasKey("InstructorID", "CourseID").HasName("PK__Teaches__F193DC630ED09521");
                        j.ToTable("Teaches");
                    });
        });

        modelBuilder.Entity<Interaction_log>(entity =>
        {
            entity.HasKey(e => e.LogID).HasName("PK__Interact__5E5499A8F6C5F0AA");

            entity.ToTable("Interaction_log");

            entity.Property(e => e.LogID).ValueGeneratedNever();
            entity.Property(e => e.action_type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.interaction_Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Learner).WithMany(p => p.Interaction_logs)
                .HasForeignKey(d => d.LearnerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Interacti__Learn__4E88ABD4");

            entity.HasOne(d => d.activity).WithMany(p => p.Interaction_logs)
                .HasForeignKey(d => d.activity_ID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Interacti__activ__4D94879B");
        });

        modelBuilder.Entity<Leaderboard>(entity =>
        {
            entity.HasKey(e => e.BoardID).HasName("PK__Leaderbo__F9646BD2BF9190BD");

            entity.ToTable("Leaderboard");

            entity.Property(e => e.BoardID).ValueGeneratedNever();
            entity.Property(e => e.season)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.LearnerID).HasName("PK__Learner__67ABFCFA8F7B42E4");

            entity.ToTable("Learner");

            entity.Property(e => e.LearnerID).ValueGeneratedNever();
            entity.Property(e => e.country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.cultural_background)
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
            entity.HasKey(e => new { e.ForumID, e.LearnerID, e.discussion_time }).HasName("PK__LearnerD__91B2B1CB1A3AFED5");

            entity.ToTable("LearnerDiscussion");

            entity.Property(e => e.discussion_time).HasColumnType("datetime");
            entity.Property(e => e.Post)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Forum).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.ForumID)
                .HasConstraintName("FK__LearnerDi__Forum__208CD6FA");

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnerDiscussions)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearnerDi__Learn__2180FB33");
        });

        modelBuilder.Entity<LearnersCollaboration>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.QuestID }).HasName("PK__Learners__CCCDE556724214E6");

            entity.ToTable("LearnersCollaboration");

            entity.Property(e => e.completion_status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearnersC__Learn__160F4887");

            entity.HasOne(d => d.Quest).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.QuestID)
                .HasConstraintName("FK__LearnersC__Quest__17036CC0");
        });

        modelBuilder.Entity<LearnersMastery>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.QuestID, e.skill }).HasName("PK__Learners__36F2E7737C70C96D");

            entity.ToTable("LearnersMastery");

            entity.Property(e => e.skill)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.completion_status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearnersMasteries)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearnersM__Learn__19DFD96B");

            entity.HasOne(d => d.Skill_Mastery).WithMany(p => p.LearnersMasteries)
                .HasForeignKey(d => new { d.QuestID, d.skill })
                .HasConstraintName("FK__LearnersMastery__1AD3FDA4");
        });

        modelBuilder.Entity<LearningPreference>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.preference }).HasName("PK__Learning__6032E158BA463788");

            entity.ToTable("LearningPreference");

            entity.Property(e => e.preference)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.LearningPreferences)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__LearningP__Learn__29572725");
        });

        modelBuilder.Entity<Learning_activity>(entity =>
        {
            entity.HasKey(e => e.ActivityID).HasName("PK__Learning__45F4A7F11B05EED6");

            entity.Property(e => e.activity_type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.instruction_details).IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Learning_activities)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Learning_activit__4AB81AF0");
        });

        modelBuilder.Entity<Learning_goal>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Learning__3214EC2750C5FF3F");

            entity.ToTable("Learning_goal");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.goal_description).IsUnicode(false);
            entity.Property(e => e.goal_status).IsUnicode(false);

            entity.HasMany(d => d.Learners).WithMany(p => p.Goals)
                .UsingEntity<Dictionary<string, object>>(
                    "LearnersGoal",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("LearnerID")
                        .HasConstraintName("FK__LearnersG__Learn__72C60C4A"),
                    l => l.HasOne<Learning_goal>().WithMany()
                        .HasForeignKey("GoalID")
                        .HasConstraintName("FK__LearnersG__GoalI__71D1E811"),
                    j =>
                    {
                        j.HasKey("GoalID", "LearnerID").HasName("PK__Learners__3C3540FE77C6ED64");
                        j.ToTable("LearnersGoals");
                    });
        });

        modelBuilder.Entity<Learning_path>(entity =>
        {
            entity.HasKey(e => e.pathID).HasName("PK__Learning__BFB8200AE173267B");

            entity.ToTable("Learning_path");

            entity.Property(e => e.adaptive_rules).IsUnicode(false);
            entity.Property(e => e.completion_status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.custom_content).IsUnicode(false);

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.Learning_paths)
                .HasForeignKey(d => new { d.LearnerID, d.ProfileID })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Learning_path__5535A963");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => new { e.ModuleID, e.CourseID }).HasName("PK__Modules__47E6A09F4E5DC62B");

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
                .HasConstraintName("FK__Modules__CourseI__38996AB5");
        });

        modelBuilder.Entity<ModuleContent>(entity =>
        {
            entity.HasKey(e => new { e.ModuleID, e.CourseID, e.content_type }).HasName("PK__ModuleCo__402E75DAF4E9F547");

            entity.ToTable("ModuleContent");

            entity.Property(e => e.content_type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleContents)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .HasConstraintName("FK__ModuleContent__3E52440B");
        });

        modelBuilder.Entity<Pathreview>(entity =>
        {
            entity.HasKey(e => new { e.InstructorID, e.PathID }).HasName("PK__Pathrevi__11D776B879F9BB86");

            entity.ToTable("Pathreview");

            entity.Property(e => e.review)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Instructor).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.InstructorID)
                .HasConstraintName("FK__Pathrevie__Instr__59FA5E80");

            entity.HasOne(d => d.Path).WithMany(p => p.Pathreviews)
                .HasForeignKey(d => d.PathID)
                .HasConstraintName("FK__Pathrevie__PathI__5AEE82B9");
        });

        modelBuilder.Entity<PersonalizationProfile>(entity =>
        {
            entity.HasKey(e => new { e.LearnerID, e.ProfileID }).HasName("PK__Personal__353B347201103333");

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
                .HasConstraintName("FK__Personali__Learn__2C3393D0");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QuestID).HasName("PK__Quest__B6619ACBB218F05D");

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
            entity.HasKey(e => new { e.RewardID, e.QuestID, e.LearnerID }).HasName("PK__QuestRew__D251A7C9B01A675E");

            entity.ToTable("QuestReward");

            entity.Property(e => e.Time_earned).HasColumnType("datetime");

            entity.HasOne(d => d.Learner).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__QuestRewa__Learn__2645B050");

            entity.HasOne(d => d.Quest).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.QuestID)
                .HasConstraintName("FK__QuestRewa__Quest__25518C17");

            entity.HasOne(d => d.Reward).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.RewardID)
                .HasConstraintName("FK__QuestRewa__Rewar__245D67DE");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => new { e.BoardID, e.LearnerID, e.CourseID }).HasName("PK__Ranking__C9D7F96CA227F55E");

            entity.ToTable("Ranking");

            entity.HasOne(d => d.Board).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.BoardID)
                .HasConstraintName("FK__Ranking__BoardID__6B24EA82");

            entity.HasOne(d => d.Course).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.CourseID)
                .HasConstraintName("FK__Ranking__CourseI__6D0D32F4");

            entity.HasOne(d => d.Learner).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Ranking__Learner__6C190EBB");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.RewardID).HasName("PK__Reward__82501599F9778199");

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
            entity.HasKey(e => new { e.LearnerID, e.skill }).HasName("PK__Skills__C45BDEA5A2E504C0");

            entity.Property(e => e.skill)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Learner).WithMany(p => p.Skills)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Skills__LearnerI__267ABA7A");
        });

        modelBuilder.Entity<SkillProgression>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__SkillPro__3214EC277C0F6D66");

            entity.ToTable("SkillProgression");

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
                .HasConstraintName("FK__SkillProgression__05D8E0BE");
        });

        modelBuilder.Entity<Skill_Mastery>(entity =>
        {
            entity.HasKey(e => new { e.QuestID, e.skill }).HasName("PK__Skill_Ma__1591B89456D71D97");

            entity.ToTable("Skill_Mastery");

            entity.Property(e => e.skill)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Quest).WithMany(p => p.Skill_Masteries)
                .HasForeignKey(d => d.QuestID)
                .HasConstraintName("FK__Skill_Mas__Quest__10566F31");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Survey__3214EC27E42B9E8C");

            entity.ToTable("Survey");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SurveyQuestion>(entity =>
        {
            entity.HasKey(e => new { e.SurveyID, e.Question }).HasName("PK__SurveyQu__23FB983B16F5782A");

            entity.Property(e => e.Question)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestions)
                .HasForeignKey(d => d.SurveyID)
                .HasConstraintName("FK__SurveyQue__Surve__778AC167");
        });

        modelBuilder.Entity<SystemNotification>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__SystemNo__3214EC2787848BC9");

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
                        .HasConstraintName("FK__ReceivedN__Learn__01142BA1"),
                    l => l.HasOne<SystemNotification>().WithMany()
                        .HasForeignKey("NotificationID")
                        .HasConstraintName("FK__ReceivedN__Notif__00200768"),
                    j =>
                    {
                        j.HasKey("NotificationID", "LearnerID").HasName("PK__Received__96B591FDE2DB0F7F");
                        j.ToTable("ReceivedNotification");
                    });
        });

        modelBuilder.Entity<Takenassessment>(entity =>
        {
            entity.HasKey(e => new { e.AssessmentID, e.LearnerID }).HasName("PK__Takenass__8B5147F157E181F7");

            entity.ToTable("Takenassessment");

            entity.HasOne(d => d.Assessment).WithMany(p => p.Takenassessments)
                .HasForeignKey(d => d.AssessmentID)
                .HasConstraintName("FK__Takenasse__Asses__47DBAE45");

            entity.HasOne(d => d.Learner).WithMany(p => p.Takenassessments)
                .HasForeignKey(d => d.LearnerID)
                .HasConstraintName("FK__Takenasse__Learn__46E78A0C");
        });

        modelBuilder.Entity<Target_trait>(entity =>
        {
            entity.HasKey(e => new { e.ModuleID, e.CourseID, e.Trait }).HasName("PK__Target_t__4E005E4CBBDCE436");

            entity.Property(e => e.Trait)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.Target_traits)
                .HasForeignKey(d => new { d.ModuleID, d.CourseID })
                .HasConstraintName("FK__Target_traits__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
