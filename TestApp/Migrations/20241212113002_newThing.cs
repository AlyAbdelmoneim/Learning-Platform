using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class newThing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalizationProfiles_Learner_LearnerID",
                table: "PersonalizationProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Teaches__F193DC630634C454",
                table: "Teaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Target_t__4E005E4CD2539EE0",
                table: "Target_traits");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Takenass__8B5147F1302C63FB",
                table: "Takenassessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SystemNo__3214EC27F00C9027",
                table: "SystemNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SurveyQu__23FB983B1273A613",
                table: "SurveyQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Survey__3214EC27B9CDD96C",
                table: "Survey");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Skills__C45BDEA564F3721F",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SkillPro__3214EC273F795C65",
                table: "SkillProgression");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Skill_Ma__1591B89457A623BE",
                table: "Skill_Mastery");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Reward__82501599D00DD99F",
                table: "Reward");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Received__96B591FD05065B4E",
                table: "ReceivedNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Ranking__C9D7F96C2F89C0EF",
                table: "Ranking");

            migrationBuilder.DropPrimaryKey(
                name: "PK__QuestRew__D251A7C972BCA27D",
                table: "QuestReward");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Quest__B6619ACBC1E92C53",
                table: "Quest");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Personal__353B34725964D150",
                table: "PersonalizationProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Pathrevi__11D776B81C453A6B",
                table: "Pathreview");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Modules__47E6A09FE7B7A463",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ModuleCo__402E75DAFC72DB74",
                table: "ModuleContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__6032E1580B26F4D5",
                table: "LearningPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__BFB8200AE49E9D65",
                table: "Learning_path");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__3214EC270E57B92D",
                table: "Learning_goal");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__45F4A7F1F2085D9E",
                table: "Learning_activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learners__36F2E773351E4BB2",
                table: "LearnersMastery");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learners__3C3540FE93723620",
                table: "LearnersGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learners__CCCDE5568F60DBF8",
                table: "LearnersCollaboration");

            migrationBuilder.DropPrimaryKey(
                name: "PK__LearnerD__91B2B1CB756DD628",
                table: "LearnerDiscussion");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learner__67ABFCFA30E07985",
                table: "Learner");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Leaderbo__F9646BD2DF1DBF14",
                table: "Leaderboard");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Interact__5E5499A818E6BADE",
                table: "Interaction_log");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Instruct__9D010B7BD46B0427",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK__HealthCo__930320B0583C47B5",
                table: "HealthCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FilledSu__1332A052D8F4C48A",
                table: "FilledSurvey");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Emotiona__C39BFD41543B8D51",
                table: "Emotionalfeedback_review");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Emotiona__6A4BEDF6D4219EB3",
                table: "Emotional_feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discussi__BBA7A440C78DD2E8",
                table: "Discussion_forum");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CoursePr__F8693C2CD1C66F08",
                table: "CoursePrerequisite");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Course_e__7F6877FBDE714736",
                table: "Course_enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Course__C92D7187EB6968B1",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ContentL__3214EC27E90B6A35",
                table: "ContentLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Collabor__B6619ACB14CD0D61",
                table: "Collaborative");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Badge__1918237CFFDBF398",
                table: "Badge");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Assessme__3214EC27508ED874",
                table: "Assessments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Admin__719FE4E817592A92",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Achievem__276330E082B30C98",
                table: "Achievement");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Learner",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                defaultValue: "TestApp/wwwroot/default_pp.png",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldDefaultValue: "TestApp/wwwroot/default_pp.png");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Teaches__F193DC639D324480",
                table: "Teaches",
                columns: new[] { "InstructorID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Target_t__4E005E4C6E933DD0",
                table: "Target_traits",
                columns: new[] { "ModuleID", "CourseID", "Trait" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Takenass__8B5147F11254B660",
                table: "Takenassessment",
                columns: new[] { "AssessmentID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__SystemNo__3214EC278EFDB7DF",
                table: "SystemNotification",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SurveyQu__23FB983B08081821",
                table: "SurveyQuestions",
                columns: new[] { "SurveyID", "Question" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Survey__3214EC279A973FA1",
                table: "Survey",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Skills__C45BDEA5F5FFC415",
                table: "Skills",
                columns: new[] { "LearnerID", "skill" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__SkillPro__3214EC2704F0C95C",
                table: "SkillProgression",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Skill_Ma__1591B8949CE5502E",
                table: "Skill_Mastery",
                columns: new[] { "QuestID", "skill" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Reward__8250159921518492",
                table: "Reward",
                column: "RewardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Received__96B591FD6DEA2A48",
                table: "ReceivedNotification",
                columns: new[] { "NotificationID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Ranking__C9D7F96C2F9AE417",
                table: "Ranking",
                columns: new[] { "BoardID", "LearnerID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__QuestRew__D251A7C9ED7C616C",
                table: "QuestReward",
                columns: new[] { "RewardID", "QuestID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Quest__B6619ACB93632AA0",
                table: "Quest",
                column: "QuestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Personal__353B34728D0715A7",
                table: "PersonalizationProfiles",
                columns: new[] { "LearnerID", "ProfileID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Pathrevi__11D776B84327C742",
                table: "Pathreview",
                columns: new[] { "InstructorID", "PathID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Modules__47E6A09F631D31CC",
                table: "Modules",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__ModuleCo__402E75DAFE821ED0",
                table: "ModuleContent",
                columns: new[] { "ModuleID", "CourseID", "content_type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__6032E158761BD620",
                table: "LearningPreference",
                columns: new[] { "LearnerID", "preference" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__BFB8200AB84ECCF4",
                table: "Learning_path",
                column: "pathID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__3214EC27C1F5F0D4",
                table: "Learning_goal",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__45F4A7F190DF0BE5",
                table: "Learning_activities",
                column: "ActivityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learners__36F2E77396FA043D",
                table: "LearnersMastery",
                columns: new[] { "LearnerID", "QuestID", "skill" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learners__3C3540FE9F5F7136",
                table: "LearnersGoals",
                columns: new[] { "GoalID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learners__CCCDE556925AC0F7",
                table: "LearnersCollaboration",
                columns: new[] { "LearnerID", "QuestID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__LearnerD__91B2B1CB0CF95611",
                table: "LearnerDiscussion",
                columns: new[] { "ForumID", "LearnerID", "discussion_time" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learner__67ABFCFA1CEDCDDD",
                table: "Learner",
                column: "LearnerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Leaderbo__F9646BD266EA5F8C",
                table: "Leaderboard",
                column: "BoardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Interact__5E5499A8D4CF4832",
                table: "Interaction_log",
                column: "LogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Instruct__9D010B7B98AB0F9E",
                table: "Instructor",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__HealthCo__930320B00B5B9A95",
                table: "HealthCondition",
                columns: new[] { "LearnerID", "ProfileID", "condition" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__FilledSu__1332A0523433A8A3",
                table: "FilledSurvey",
                columns: new[] { "SurveyID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Emotiona__C39BFD41CFB8D375",
                table: "Emotionalfeedback_review",
                columns: new[] { "FeedbackID", "InstructorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Emotiona__6A4BEDF66CC76355",
                table: "Emotional_feedback",
                column: "FeedbackID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discussi__BBA7A44095B8D840",
                table: "Discussion_forum",
                column: "forumID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CoursePr__F8693C2CBEA7A8BF",
                table: "CoursePrerequisite",
                columns: new[] { "CourseID", "Prereq" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Course_e__7F6877FBD2208383",
                table: "Course_enrollment",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Course__C92D71878A4A1FE1",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ContentL__3214EC27AA63B857",
                table: "ContentLibrary",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Collabor__B6619ACBEACF8729",
                table: "Collaborative",
                column: "QuestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Badge__1918237C48EFC7A1",
                table: "Badge",
                column: "BadgeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Assessme__3214EC2751DEFC11",
                table: "Assessments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Admin__719FE4E89DE9DF33",
                table: "Admin",
                column: "AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Achievem__276330E037C96567",
                table: "Achievement",
                column: "AchievementID");

            migrationBuilder.AddForeignKey(
                name: "FK__Personali__Learn__2E1BDC42",
                table: "PersonalizationProfiles",
                column: "LearnerID",
                principalTable: "Learner",
                principalColumn: "LearnerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Personali__Learn__2E1BDC42",
                table: "PersonalizationProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Teaches__F193DC639D324480",
                table: "Teaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Target_t__4E005E4C6E933DD0",
                table: "Target_traits");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Takenass__8B5147F11254B660",
                table: "Takenassessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SystemNo__3214EC278EFDB7DF",
                table: "SystemNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SurveyQu__23FB983B08081821",
                table: "SurveyQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Survey__3214EC279A973FA1",
                table: "Survey");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Skills__C45BDEA5F5FFC415",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SkillPro__3214EC2704F0C95C",
                table: "SkillProgression");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Skill_Ma__1591B8949CE5502E",
                table: "Skill_Mastery");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Reward__8250159921518492",
                table: "Reward");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Received__96B591FD6DEA2A48",
                table: "ReceivedNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Ranking__C9D7F96C2F9AE417",
                table: "Ranking");

            migrationBuilder.DropPrimaryKey(
                name: "PK__QuestRew__D251A7C9ED7C616C",
                table: "QuestReward");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Quest__B6619ACB93632AA0",
                table: "Quest");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Personal__353B34728D0715A7",
                table: "PersonalizationProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Pathrevi__11D776B84327C742",
                table: "Pathreview");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Modules__47E6A09F631D31CC",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ModuleCo__402E75DAFE821ED0",
                table: "ModuleContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__6032E158761BD620",
                table: "LearningPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__BFB8200AB84ECCF4",
                table: "Learning_path");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__3214EC27C1F5F0D4",
                table: "Learning_goal");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learning__45F4A7F190DF0BE5",
                table: "Learning_activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learners__36F2E77396FA043D",
                table: "LearnersMastery");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learners__3C3540FE9F5F7136",
                table: "LearnersGoals");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learners__CCCDE556925AC0F7",
                table: "LearnersCollaboration");

            migrationBuilder.DropPrimaryKey(
                name: "PK__LearnerD__91B2B1CB0CF95611",
                table: "LearnerDiscussion");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Learner__67ABFCFA1CEDCDDD",
                table: "Learner");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Leaderbo__F9646BD266EA5F8C",
                table: "Leaderboard");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Interact__5E5499A8D4CF4832",
                table: "Interaction_log");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Instruct__9D010B7B98AB0F9E",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK__HealthCo__930320B00B5B9A95",
                table: "HealthCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FilledSu__1332A0523433A8A3",
                table: "FilledSurvey");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Emotiona__C39BFD41CFB8D375",
                table: "Emotionalfeedback_review");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Emotiona__6A4BEDF66CC76355",
                table: "Emotional_feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Discussi__BBA7A44095B8D840",
                table: "Discussion_forum");

            migrationBuilder.DropPrimaryKey(
                name: "PK__CoursePr__F8693C2CBEA7A8BF",
                table: "CoursePrerequisite");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Course_e__7F6877FBD2208383",
                table: "Course_enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Course__C92D71878A4A1FE1",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ContentL__3214EC27AA63B857",
                table: "ContentLibrary");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Collabor__B6619ACBEACF8729",
                table: "Collaborative");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Badge__1918237C48EFC7A1",
                table: "Badge");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Assessme__3214EC2751DEFC11",
                table: "Assessments");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Admin__719FE4E89DE9DF33",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Achievem__276330E037C96567",
                table: "Achievement");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Learner",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "TestApp/wwwroot/default_pp.png",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true,
                oldDefaultValue: "TestApp/wwwroot/default_pp.png");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Teaches__F193DC630634C454",
                table: "Teaches",
                columns: new[] { "InstructorID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Target_t__4E005E4CD2539EE0",
                table: "Target_traits",
                columns: new[] { "ModuleID", "CourseID", "Trait" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Takenass__8B5147F1302C63FB",
                table: "Takenassessment",
                columns: new[] { "AssessmentID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__SystemNo__3214EC27F00C9027",
                table: "SystemNotification",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SurveyQu__23FB983B1273A613",
                table: "SurveyQuestions",
                columns: new[] { "SurveyID", "Question" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Survey__3214EC27B9CDD96C",
                table: "Survey",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Skills__C45BDEA564F3721F",
                table: "Skills",
                columns: new[] { "LearnerID", "skill" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__SkillPro__3214EC273F795C65",
                table: "SkillProgression",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Skill_Ma__1591B89457A623BE",
                table: "Skill_Mastery",
                columns: new[] { "QuestID", "skill" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Reward__82501599D00DD99F",
                table: "Reward",
                column: "RewardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Received__96B591FD05065B4E",
                table: "ReceivedNotification",
                columns: new[] { "NotificationID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Ranking__C9D7F96C2F89C0EF",
                table: "Ranking",
                columns: new[] { "BoardID", "LearnerID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__QuestRew__D251A7C972BCA27D",
                table: "QuestReward",
                columns: new[] { "RewardID", "QuestID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Quest__B6619ACBC1E92C53",
                table: "Quest",
                column: "QuestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Personal__353B34725964D150",
                table: "PersonalizationProfiles",
                columns: new[] { "LearnerID", "ProfileID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Pathrevi__11D776B81C453A6B",
                table: "Pathreview",
                columns: new[] { "InstructorID", "PathID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Modules__47E6A09FE7B7A463",
                table: "Modules",
                columns: new[] { "ModuleID", "CourseID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__ModuleCo__402E75DAFC72DB74",
                table: "ModuleContent",
                columns: new[] { "ModuleID", "CourseID", "content_type" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__6032E1580B26F4D5",
                table: "LearningPreference",
                columns: new[] { "LearnerID", "preference" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__BFB8200AE49E9D65",
                table: "Learning_path",
                column: "pathID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__3214EC270E57B92D",
                table: "Learning_goal",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learning__45F4A7F1F2085D9E",
                table: "Learning_activities",
                column: "ActivityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learners__36F2E773351E4BB2",
                table: "LearnersMastery",
                columns: new[] { "LearnerID", "QuestID", "skill" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learners__3C3540FE93723620",
                table: "LearnersGoals",
                columns: new[] { "GoalID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learners__CCCDE5568F60DBF8",
                table: "LearnersCollaboration",
                columns: new[] { "LearnerID", "QuestID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__LearnerD__91B2B1CB756DD628",
                table: "LearnerDiscussion",
                columns: new[] { "ForumID", "LearnerID", "discussion_time" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Learner__67ABFCFA30E07985",
                table: "Learner",
                column: "LearnerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Leaderbo__F9646BD2DF1DBF14",
                table: "Leaderboard",
                column: "BoardID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Interact__5E5499A818E6BADE",
                table: "Interaction_log",
                column: "LogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Instruct__9D010B7BD46B0427",
                table: "Instructor",
                column: "InstructorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__HealthCo__930320B0583C47B5",
                table: "HealthCondition",
                columns: new[] { "LearnerID", "ProfileID", "condition" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__FilledSu__1332A052D8F4C48A",
                table: "FilledSurvey",
                columns: new[] { "SurveyID", "LearnerID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Emotiona__C39BFD41543B8D51",
                table: "Emotionalfeedback_review",
                columns: new[] { "FeedbackID", "InstructorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Emotiona__6A4BEDF6D4219EB3",
                table: "Emotional_feedback",
                column: "FeedbackID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Discussi__BBA7A440C78DD2E8",
                table: "Discussion_forum",
                column: "forumID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CoursePr__F8693C2CD1C66F08",
                table: "CoursePrerequisite",
                columns: new[] { "CourseID", "Prereq" });

            migrationBuilder.AddPrimaryKey(
                name: "PK__Course_e__7F6877FBDE714736",
                table: "Course_enrollment",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Course__C92D7187EB6968B1",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ContentL__3214EC27E90B6A35",
                table: "ContentLibrary",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Collabor__B6619ACB14CD0D61",
                table: "Collaborative",
                column: "QuestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Badge__1918237CFFDBF398",
                table: "Badge",
                column: "BadgeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Assessme__3214EC27508ED874",
                table: "Assessments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Admin__719FE4E817592A92",
                table: "Admin",
                column: "AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Achievem__276330E082B30C98",
                table: "Achievement",
                column: "AchievementID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalizationProfiles_Learner_LearnerID",
                table: "PersonalizationProfiles",
                column: "LearnerID",
                principalTable: "Learner",
                principalColumn: "LearnerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
