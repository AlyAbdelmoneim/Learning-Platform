using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureToAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    adminPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__719FE4E817592A92", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    BadgeID = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    badge_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    criteria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Badge__1918237CFFDBF398", x => x.BadgeID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    learning_objective = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    credit_points = table.Column<int>(type: "int", nullable: true),
                    difficulty_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    course_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__C92D7187EB6968B1", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    instructor_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    latest_qualification = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    expertise_area = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    adminPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruct__9D010B7BD46B0427", x => x.InstructorID);
                });

            migrationBuilder.CreateTable(
                name: "Leaderboard",
                columns: table => new
                {
                    BoardID = table.Column<int>(type: "int", nullable: false),
                    season = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Leaderbo__F9646BD2DF1DBF14", x => x.BoardID);
                });

            migrationBuilder.CreateTable(
                name: "Learner",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePicture = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false, defaultValue: "TestApp/wwwroot/default_pp.png"),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: true),
                    country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    cultural_background = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    adminPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learner__67ABFCFA30E07985", x => x.LearnerID);
                });

            migrationBuilder.CreateTable(
                name: "Learning_goal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    goal_status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    goal_description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__3214EC270E57B92D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quest",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    difficulty_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    criteria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    quest_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quest__B6619ACBC1E92C53", x => x.QuestID);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    RewardID = table.Column<int>(type: "int", nullable: false),
                    reward_value = table.Column<int>(type: "int", nullable: true),
                    reward_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    reward_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reward__82501599D00DD99F", x => x.RewardID);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Survey__3214EC27B9CDD96C", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SystemNotification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    notification_timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    notification_message = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    urgency_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ReadStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SystemNo__3214EC27F00C9027", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrerequisite",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Prereq = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CoursePr__F8693C2CD1C66F08", x => new { x.CourseID, x.Prereq });
                    table.ForeignKey(
                        name: "FK__CoursePre__Cours__35BCFE0A",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CoursePre__Prere__36B12243",
                        column: x => x.Prereq,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    difficulty = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    contentURL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modules__47E6A09FE7B7A463", x => new { x.ModuleID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Modules__CourseI__3A81B327",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teaches__F193DC630634C454", x => new { x.InstructorID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Teaches__CourseI__68487DD7",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Teaches__Instruc__6754599E",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    BadgeID = table.Column<int>(type: "int", nullable: true),
                    achievement_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    date_earned = table.Column<DateOnly>(type: "date", nullable: true),
                    achievement_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Achievem__276330E082B30C98", x => x.AchievementID);
                    table.ForeignKey(
                        name: "FK__Achieveme__Badge__0B91BA14",
                        column: x => x.BadgeID,
                        principalTable: "Badge",
                        principalColumn: "BadgeID");
                    table.ForeignKey(
                        name: "FK__Achieveme__Learn__0A9D95DB",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID");
                });

            migrationBuilder.CreateTable(
                name: "Course_enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true),
                    enrollment_date = table.Column<DateOnly>(type: "date", nullable: true),
                    enrollment_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course_e__7F6877FBDE714736", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK__Course_en__Cours__6383C8BA",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Course_en__Learn__6477ECF3",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningPreference",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    preference = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__6032E1580B26F4D5", x => new { x.LearnerID, x.preference });
                    table.ForeignKey(
                        name: "FK__LearningP__Learn__2B3F6F97",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalizationProfiles",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefered_content_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    emotional_state = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    personality_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__353B34725964D150", x => new { x.LearnerID, x.ProfileID });
                    table.ForeignKey(
                        name: "FK_PersonalizationProfiles_Learner_LearnerID",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    BoardID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    rankNum = table.Column<int>(type: "int", nullable: true),
                    total_points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ranking__C9D7F96C2F89C0EF", x => new { x.BoardID, x.LearnerID, x.CourseID });
                    table.ForeignKey(
                        name: "FK__Ranking__BoardID__6D0D32F4",
                        column: x => x.BoardID,
                        principalTable: "Leaderboard",
                        principalColumn: "BoardID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Ranking__CourseI__6EF57B66",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Ranking__Learner__6E01572D",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skills__C45BDEA564F3721F", x => new { x.LearnerID, x.skill });
                    table.ForeignKey(
                        name: "FK__Skills__LearnerI__286302EC",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnersGoals",
                columns: table => new
                {
                    GoalID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learners__3C3540FE93723620", x => new { x.GoalID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__LearnersG__GoalI__73BA3083",
                        column: x => x.GoalID,
                        principalTable: "Learning_goal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnersG__Learn__74AE54BC",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborative",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    max_num_participants = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Collabor__B6619ACB14CD0D61", x => x.QuestID);
                    table.ForeignKey(
                        name: "FK__Collabora__Quest__151B244E",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill_Mastery",
                columns: table => new
                {
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skill_Ma__1591B89457A623BE", x => new { x.QuestID, x.skill });
                    table.ForeignKey(
                        name: "FK__Skill_Mas__Quest__123EB7A3",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestReward",
                columns: table => new
                {
                    RewardID = table.Column<int>(type: "int", nullable: false),
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Time_earned = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QuestRew__D251A7C972BCA27D", x => new { x.RewardID, x.QuestID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__QuestRewa__Learn__282DF8C2",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__QuestRewa__Quest__2739D489",
                        column: x => x.QuestID,
                        principalTable: "Quest",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__QuestRewa__Rewar__2645B050",
                        column: x => x.RewardID,
                        principalTable: "Reward",
                        principalColumn: "RewardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilledSurvey",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FilledSu__1332A052D8F4C48A", x => new { x.SurveyID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__FilledSur__Learn__7D439ABD",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FilledSur__Surve__7C4F7684",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SurveyQu__23FB983B1273A613", x => new { x.SurveyID, x.Question });
                    table.ForeignKey(
                        name: "FK__SurveyQue__Surve__797309D9",
                        column: x => x.SurveyID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedNotification",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Received__96B591FD05065B4E", x => new { x.NotificationID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__ReceivedN__Learn__02FC7413",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ReceivedN__Notif__02084FDA",
                        column: x => x.NotificationID,
                        principalTable: "SystemNotification",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    assessment_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    total_marks = table.Column<int>(type: "int", nullable: true),
                    passing_marks = table.Column<int>(type: "int", nullable: true),
                    criteria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    weightage = table.Column<int>(type: "int", nullable: true),
                    assessment_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assessme__3214EC27508ED874", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Assessments__45F365D3",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentLibrary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    library_description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    metadata = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    library_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    content_URL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContentL__3214EC27E90B6A35", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ContentLibrary__4316F928",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discussion_forum",
                columns: table => new
                {
                    forumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    last_active = table.Column<TimeOnly>(type: "time", nullable: true),
                    forum_timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    forum_description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discussi__BBA7A440C78DD2E8", x => x.forumID);
                    table.ForeignKey(
                        name: "FK__Discussion_forum__1F98B2C1",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learning_activities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    activity_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    instruction_details = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Max_points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__45F4A7F1F2085D9E", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK__Learning_activit__4CA06362",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleContent",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    content_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModuleCo__402E75DAFC72DB74", x => new { x.ModuleID, x.CourseID, x.content_type });
                    table.ForeignKey(
                        name: "FK__ModuleContent__403A8C7D",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Target_traits",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Trait = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Target_t__4E005E4CD2539EE0", x => new { x.ModuleID, x.CourseID, x.Trait });
                    table.ForeignKey(
                        name: "FK__Target_traits__3D5E1FD2",
                        columns: x => new { x.ModuleID, x.CourseID },
                        principalTable: "Modules",
                        principalColumns: new[] { "ModuleID", "CourseID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthCondition",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    condition = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HealthCo__930320B0583C47B5", x => new { x.LearnerID, x.ProfileID, x.condition });
                    table.ForeignKey(
                        name: "FK__HealthCondition__30F848ED",
                        columns: x => new { x.LearnerID, x.ProfileID },
                        principalTable: "PersonalizationProfiles",
                        principalColumns: new[] { "LearnerID", "ProfileID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Learning_path",
                columns: table => new
                {
                    pathID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    ProfileID = table.Column<int>(type: "int", nullable: true),
                    completion_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    custom_content = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    adaptive_rules = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__BFB8200AE49E9D65", x => x.pathID);
                    table.ForeignKey(
                        name: "FK__Learning_path__571DF1D5",
                        columns: x => new { x.LearnerID, x.ProfileID },
                        principalTable: "PersonalizationProfiles",
                        principalColumns: new[] { "LearnerID", "ProfileID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillProgression",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    proficiency_level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    skill_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    skillProgression_timestamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SkillPro__3214EC273F795C65", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SkillProgression__07C12930",
                        columns: x => new { x.LearnerID, x.skill_name },
                        principalTable: "Skills",
                        principalColumns: new[] { "LearnerID", "skill" });
                });

            migrationBuilder.CreateTable(
                name: "LearnersCollaboration",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    completion_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learners__CCCDE5568F60DBF8", x => new { x.LearnerID, x.QuestID });
                    table.ForeignKey(
                        name: "FK__LearnersC__Learn__17F790F9",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnersC__Quest__18EBB532",
                        column: x => x.QuestID,
                        principalTable: "Collaborative",
                        principalColumn: "QuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnersMastery",
                columns: table => new
                {
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    QuestID = table.Column<int>(type: "int", nullable: false),
                    skill = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    completion_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learners__36F2E773351E4BB2", x => new { x.LearnerID, x.QuestID, x.skill });
                    table.ForeignKey(
                        name: "FK__LearnersM__Learn__1BC821DD",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnersMastery__1CBC4616",
                        columns: x => new { x.QuestID, x.skill },
                        principalTable: "Skill_Mastery",
                        principalColumns: new[] { "QuestID", "skill" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Takenassessment",
                columns: table => new
                {
                    AssessmentID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    scoredPoint = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Takenass__8B5147F1302C63FB", x => new { x.AssessmentID, x.LearnerID });
                    table.ForeignKey(
                        name: "FK__Takenasse__Asses__49C3F6B7",
                        column: x => x.AssessmentID,
                        principalTable: "Assessments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Takenasse__Learn__48CFD27E",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnerDiscussion",
                columns: table => new
                {
                    ForumID = table.Column<int>(type: "int", nullable: false),
                    LearnerID = table.Column<int>(type: "int", nullable: false),
                    discussion_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Post = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerD__91B2B1CB756DD628", x => new { x.ForumID, x.LearnerID, x.discussion_time });
                    table.ForeignKey(
                        name: "FK__LearnerDi__Forum__22751F6C",
                        column: x => x.ForumID,
                        principalTable: "Discussion_forum",
                        principalColumn: "forumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__LearnerDi__Learn__236943A5",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emotional_feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    activityID = table.Column<int>(type: "int", nullable: true),
                    feedback_timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    emotional_state = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emotiona__6A4BEDF6D4219EB3", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FK__Emotional__Learn__534D60F1",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Emotional__activ__5441852A",
                        column: x => x.activityID,
                        principalTable: "Learning_activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interaction_log",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false),
                    activity_ID = table.Column<int>(type: "int", nullable: true),
                    LearnerID = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    interaction_Timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    action_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interact__5E5499A818E6BADE", x => x.LogID);
                    table.ForeignKey(
                        name: "FK__Interacti__Learn__5070F446",
                        column: x => x.LearnerID,
                        principalTable: "Learner",
                        principalColumn: "LearnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Interacti__activ__4F7CD00D",
                        column: x => x.activity_ID,
                        principalTable: "Learning_activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pathreview",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    PathID = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pathrevi__11D776B81C453A6B", x => new { x.InstructorID, x.PathID });
                    table.ForeignKey(
                        name: "FK__Pathrevie__Instr__5BE2A6F2",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Pathrevie__PathI__5CD6CB2B",
                        column: x => x.PathID,
                        principalTable: "Learning_path",
                        principalColumn: "pathID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emotionalfeedback_review",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emotiona__C39BFD41543B8D51", x => new { x.FeedbackID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK__Emotional__Feedb__5FB337D6",
                        column: x => x.FeedbackID,
                        principalTable: "Emotional_feedback",
                        principalColumn: "FeedbackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Emotional__Instr__60A75C0F",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstructorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_BadgeID",
                table: "Achievement",
                column: "BadgeID");

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_LearnerID",
                table: "Achievement",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ModuleID_CourseID",
                table: "Assessments",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_ContentLibrary_ModuleID_CourseID",
                table: "ContentLibrary",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_enrollment_CourseID",
                table: "Course_enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_enrollment_LearnerID",
                table: "Course_enrollment",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisite_Prereq",
                table: "CoursePrerequisite",
                column: "Prereq");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_forum_ModuleID_CourseID",
                table: "Discussion_forum",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Emotional_feedback_activityID",
                table: "Emotional_feedback",
                column: "activityID");

            migrationBuilder.CreateIndex(
                name: "IX_Emotional_feedback_LearnerID",
                table: "Emotional_feedback",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Emotionalfeedback_review_InstructorID",
                table: "Emotionalfeedback_review",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_FilledSurvey_LearnerID",
                table: "FilledSurvey",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_log_activity_ID",
                table: "Interaction_log",
                column: "activity_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_log_LearnerID",
                table: "Interaction_log",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerDiscussion_LearnerID",
                table: "LearnerDiscussion",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnersCollaboration_QuestID",
                table: "LearnersCollaboration",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnersGoals_LearnerID",
                table: "LearnersGoals",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnersMastery_QuestID_skill",
                table: "LearnersMastery",
                columns: new[] { "QuestID", "skill" });

            migrationBuilder.CreateIndex(
                name: "IX_Learning_activities_ModuleID_CourseID",
                table: "Learning_activities",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_Learning_path_LearnerID_ProfileID",
                table: "Learning_path",
                columns: new[] { "LearnerID", "ProfileID" });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CourseID",
                table: "Modules",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Pathreview_PathID",
                table: "Pathreview",
                column: "PathID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestReward_LearnerID",
                table: "QuestReward",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestReward_QuestID",
                table: "QuestReward",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_CourseID",
                table: "Ranking",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_LearnerID",
                table: "Ranking",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedNotification_LearnerID",
                table: "ReceivedNotification",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillProgression_LearnerID_skill_name",
                table: "SkillProgression",
                columns: new[] { "LearnerID", "skill_name" });

            migrationBuilder.CreateIndex(
                name: "IX_Takenassessment_LearnerID",
                table: "Takenassessment",
                column: "LearnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseID",
                table: "Teaches",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ContentLibrary");

            migrationBuilder.DropTable(
                name: "Course_enrollment");

            migrationBuilder.DropTable(
                name: "CoursePrerequisite");

            migrationBuilder.DropTable(
                name: "Emotionalfeedback_review");

            migrationBuilder.DropTable(
                name: "FilledSurvey");

            migrationBuilder.DropTable(
                name: "HealthCondition");

            migrationBuilder.DropTable(
                name: "Interaction_log");

            migrationBuilder.DropTable(
                name: "LearnerDiscussion");

            migrationBuilder.DropTable(
                name: "LearnersCollaboration");

            migrationBuilder.DropTable(
                name: "LearnersGoals");

            migrationBuilder.DropTable(
                name: "LearnersMastery");

            migrationBuilder.DropTable(
                name: "LearningPreference");

            migrationBuilder.DropTable(
                name: "ModuleContent");

            migrationBuilder.DropTable(
                name: "Pathreview");

            migrationBuilder.DropTable(
                name: "QuestReward");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "ReceivedNotification");

            migrationBuilder.DropTable(
                name: "SkillProgression");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "Takenassessment");

            migrationBuilder.DropTable(
                name: "Target_traits");

            migrationBuilder.DropTable(
                name: "Teaches");

            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropTable(
                name: "Emotional_feedback");

            migrationBuilder.DropTable(
                name: "Discussion_forum");

            migrationBuilder.DropTable(
                name: "Collaborative");

            migrationBuilder.DropTable(
                name: "Learning_goal");

            migrationBuilder.DropTable(
                name: "Skill_Mastery");

            migrationBuilder.DropTable(
                name: "Learning_path");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Leaderboard");

            migrationBuilder.DropTable(
                name: "SystemNotification");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Learning_activities");

            migrationBuilder.DropTable(
                name: "Quest");

            migrationBuilder.DropTable(
                name: "PersonalizationProfiles");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Learner");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
