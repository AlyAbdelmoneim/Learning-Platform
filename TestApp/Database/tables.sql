CREATE DATABASE ProjectDatabase6;
USE ProjectDatabase6;


CREATE TABLE Admin(
    AdminID INT PRIMARY KEY  NOT NULL IDENTITY(1, 1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(50),
    adminPassword VARCHAR(50)
)

CREATE TABLE Learner
(
    LearnerID           INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    first_name          VARCHAR(50),
    last_name           VARCHAR(50),
    gender              CHAR(1),
    birth_date          DATE,
    country             VARCHAR(50),
    cultural_background VARCHAR(50),
    email VARCHAR(50),
    adminPassword VARCHAR(50)
);

CREATE TABLE Skills
(
    LearnerID INT         NOT NULL,
    skill     VARCHAR(50) NOT NULL,
    PRIMARY KEY (LearnerID, skill),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE LearningPreference
(
    LearnerID  INT         NOT NULL,
    preference VARCHAR(50) NOT NULL,
    PRIMARY KEY (LearnerID, preference),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE PersonalizationProfiles
(
    LearnerID             INT NOT NULL,
    ProfileID             INT NOT NULL IDENTITY(1, 1),
    Prefered_content_type VARCHAR(50),
    emotional_state       VARCHAR(50),
    personality_type      VARCHAR(50),
    PRIMARY KEY (LearnerID, ProfileID),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE HealthCondition
(
    LearnerID INT         NOT NULL,
    ProfileID INT         NOT NULL,
    condition VARCHAR(50) NOT NULL,
    PRIMARY KEY (LearnerID, ProfileID, condition),
    FOREIGN KEY (LearnerID, ProfileID) REFERENCES PersonalizationProfiles (LearnerID, ProfileID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Course
(
    CourseID           INT PRIMARY KEY NOT NULL,
    Title              VARCHAR(100),
    learning_objective VARCHAR(50),
    credit_points      INT,
    difficulty_level   VARCHAR(50),
    course_description VARCHAR(50)
);

--!!!!!!!!!
CREATE TABLE CoursePrerequisite
(
    CourseID INT,
    Prereq   INT,
    PRIMARY KEY (CourseID, Prereq),
    FOREIGN KEY (CourseID) REFERENCES Course (CourseID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (Prereq) REFERENCES Course (CourseID),
    CONSTRAINT chk_no_self_reference CHECK (CourseID <> Prereq) -- Prevent self-referencing
);

CREATE TABLE Modules
(
    ModuleID   INT NOT NULL,
    CourseID   INT NOT NULL,
    Title      VARCHAR(100),
    difficulty VARCHAR(50),
    contentURL VARCHAR(255),
    PRIMARY KEY (ModuleID, CourseID),
    FOREIGN KEY (CourseID) REFERENCES Course (CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Target_traits
(
    ModuleID INT         NOT NULL,
    CourseID INT         NOT NULL,
    Trait    VARCHAR(50) NOT NULL,
    PRIMARY KEY (ModuleID, CourseID, Trait),
    FOREIGN KEY (ModuleID, CourseID) REFERENCES Modules (ModuleID, CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE ModuleContent
(
    ModuleID     INT         NOT NULL,
    CourseID     INT         NOT NULL,
    content_type VARCHAR(50) NOT NULL,
    PRIMARY KEY (ModuleID, CourseID, content_type),
    FOREIGN KEY (ModuleID, CourseID) REFERENCES Modules (ModuleID, CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ContentLibrary
(
    ID                  INT PRIMARY KEY NOT NULL,
    ModuleID            INT,
    CourseID            INT,
    Title               VARCHAR(100),
    library_description VARCHAR(50),
    metadata            VARCHAR(50),
    library_type        VARCHAR(50),
    content_URL         VARCHAR(255),
    FOREIGN KEY (ModuleID, CourseID) REFERENCES Modules (ModuleID, CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Assessments
(
    ID                     INT PRIMARY KEY NOT NULL,
    ModuleID               INT,
    CourseID               INT,
    assessment_type        VARCHAR(50),
    total_marks            INT,
    passing_marks          INT,
    criteria               VARCHAR(50),
    weightage              INT,
    assessment_description VARCHAR(50),
    title                  VARCHAR(100),
    FOREIGN KEY (ModuleID, CourseID) REFERENCES Modules (ModuleID, CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Takenassessment
(
    AssessmentID INT NOT NULL,
    LearnerID    INT NOT NULL,
    scoredPoint  INT,
    PRIMARY KEY (AssessmentID, LearnerID),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (AssessmentID) REFERENCES Assessments (ID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Learning_activities
(
    ActivityID          INT PRIMARY KEY NOT NULL IDENTITY,
    ModuleID            INT,
    CourseID            INT,
    activity_type       VARCHAR(50),
    instruction_details VARCHAR(MAX),
    Max_points          INT,
    FOREIGN KEY (ModuleID, CourseID) REFERENCES Modules (ModuleID, CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Interaction_log
(
    LogID                 INT PRIMARY KEY NOT NULL,
    activity_ID           INT,
    LearnerID             INT,
    Duration              INT,
    interaction_Timestamp DATETIME,
    action_type           VARCHAR(50),
    FOREIGN KEY (activity_ID) REFERENCES Learning_activities (ActivityID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Emotional_feedback
(
    FeedbackID         INT PRIMARY KEY NOT NULL IDENTITY,
    LearnerID          INT,
    activityID         INT,
    feedback_timestamp DATETIME,
    emotional_state    VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (activityID) REFERENCES Learning_activities (ActivityID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Learning_path
(
    pathID            INT PRIMARY KEY NOT NULL IDENTITY,
    LearnerID         INT,
    ProfileID         INT,
    completion_status VARCHAR(50),
    custom_content    VARCHAR(MAX),
    adaptive_rules    VARCHAR(MAX),
    FOREIGN KEY (LearnerID, ProfileID) REFERENCES PersonalizationProfiles (LearnerID, ProfileID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Instructor
(
    InstructorID         INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    instructor_name      VARCHAR(100),
    latest_qualification VARCHAR(50),
    expertise_area       VARCHAR(50),
    email                VARCHAR(100),
    adminPassword VARCHAR(50)
);

CREATE TABLE Pathreview
(
    InstructorID INT NOT NULL,
    PathID       INT NOT NULL,
    review       VARCHAR(50),
    PRIMARY KEY (InstructorID, PathID),
    FOREIGN KEY (InstructorID) REFERENCES Instructor (InstructorID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (PathID) REFERENCES Learning_path (pathID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Emotionalfeedback_review
(
    FeedbackID   INT NOT NULL,
    InstructorID INT NOT NULL,
    review       VARCHAR(50),
    PRIMARY KEY (FeedbackID, InstructorID),
    FOREIGN KEY (FeedbackID) REFERENCES Emotional_feedback (FeedbackID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (InstructorID) REFERENCES Instructor (InstructorID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Course_enrollment
(
    EnrollmentID      INT PRIMARY KEY NOT NULL IDENTITY,
    CourseID          INT,
    LearnerID         INT,
    completion_date   DATE,
    enrollment_date   DATE,
    enrollment_status VARCHAR(50),
    FOREIGN KEY (CourseID) REFERENCES Course (CourseID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Teaches
(
    InstructorID INT NOT NULL,
    CourseID     INT NOT NULL,
    PRIMARY KEY (InstructorID, CourseID),
    FOREIGN KEY (InstructorID) REFERENCES Instructor (InstructorID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course (CourseID) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE Leaderboard
(
    BoardID INT PRIMARY KEY NOT NULL,
    season  VARCHAR(50)
);

CREATE TABLE Ranking
(
    BoardID      INT NOT NULL,
    LearnerID    INT NOT NULL,
    CourseID     INT NOT NULL,
    rankNum      INT,
    total_points INT,
    PRIMARY KEY (BoardID, LearnerID, CourseID),
    FOREIGN KEY (BoardID) REFERENCES Leaderboard (BoardID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (CourseID) REFERENCES Course (CourseID) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE Learning_goal
(
    ID               INT PRIMARY KEY NOT NULL,
    goal_status      VARCHAR(MAX),
    deadline         DATE,
    goal_description VARCHAR(MAX)
);

CREATE TABLE LearnersGoals
(
    GoalID    INT NOT NULL,
    LearnerID INT NOT NULL,
    PRIMARY KEY (GoalID, LearnerID),
    FOREIGN KEY (GoalID) REFERENCES Learning_goal (ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE Survey
(
    ID    INT PRIMARY KEY NOT NULL,
    Title VARCHAR(100)
);

CREATE TABLE SurveyQuestions
(
    SurveyID INT NOT NULL,
    Question VARCHAR(50),
    PRIMARY KEY (SurveyID, Question),
    FOREIGN KEY (SurveyID) REFERENCES Survey (ID) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE FilledSurvey
(
    SurveyID  INT NOT NULL,
    LearnerID INT NOT NULL,
    Answer    VARCHAR(50),
    PRIMARY KEY (SurveyID, LearnerID),
    FOREIGN KEY (SurveyID) REFERENCES Survey (ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
);

CREATE TABLE SystemNotification
(
    ID                     INT PRIMARY KEY NOT NULL,
    notification_timestamp DATETIME,
    notification_message   VARCHAR(MAX),
    urgency_level          VARCHAR(50),
    ReadStatus             BIT
);

CREATE TABLE ReceivedNotification
(
    NotificationID INT NOT NULL,
    LearnerID      INT NOT NULL,
    PRIMARY KEY (NotificationID, LearnerID),
    FOREIGN KEY (NotificationID) REFERENCES SystemNotification (ID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Badge
(
    BadgeID           INT PRIMARY KEY NOT NULL,
    title             VARCHAR(100),
    badge_description VARCHAR(50),
    criteria          VARCHAR(50),
    points            INT
);


CREATE TABLE SkillProgression
(
    ID                         INT PRIMARY KEY NOT NULL,
    proficiency_level          VARCHAR(50),
    LearnerID                  INT,
    skill_name                 VARCHAR(50),
    skillProgression_timestamp DATETIME,
    FOREIGN KEY (LearnerID, skill_name) REFERENCES Skills (LearnerID, skill)
);


CREATE TABLE Achievement
(
    AchievementID           INT PRIMARY KEY NOT NULL IDENTITY,
    LearnerID               INT,
    BadgeID                 INT,
    achievement_description VARCHAR(50),
    date_earned             DATE,
    achievement_type        VARCHAR(50),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID),
    FOREIGN KEY (BadgeID) REFERENCES Badge (BadgeID)
);



CREATE TABLE Reward
(
    RewardID           INT PRIMARY KEY NOT NULL,
    reward_value       INT,
    reward_description VARCHAR(50),
    reward_type        VARCHAR(50)
);


CREATE TABLE Quest
(
    QuestID           INT PRIMARY KEY NOT NULL IDENTITY,
    difficulty_level  VARCHAR(50),
    criteria          VARCHAR(50),
    quest_description VARCHAR(50),
    title             VARCHAR(100)
);

CREATE TABLE Skill_Mastery
(
    QuestID INT         NOT NULL,
    skill   VARCHAR(50) NOT NULL,
    PRIMARY KEY (QuestID, skill),
    FOREIGN KEY (QuestID) REFERENCES Quest (QuestID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Collaborative
(
    QuestID              INT PRIMARY KEY NOT NULL,
    deadline             DATE,
    max_num_participants INT,
    FOREIGN KEY (QuestID) REFERENCES Quest (QuestID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE LearnersCollaboration
(
    LearnerID         INT NOT NULL,
    QuestID           INT NOT NULL,
    completion_status VARCHAR(50),
    PRIMARY KEY (LearnerID, QuestID),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (QuestID) REFERENCES Collaborative (QuestID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE LearnersMastery
(
    LearnerID         INT         NOT NULL,
    QuestID           INT         NOT NULL,
    skill             VARCHAR(50) NOT NULL,
    completion_status VARCHAR(50),
    PRIMARY KEY (LearnerID, QuestID, skill),
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (QuestID, skill) REFERENCES Skill_Mastery (QuestID, skill) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Discussion_forum
(
    forumID           INT PRIMARY KEY NOT NULL IDENTITY,
    ModuleID          INT,
    CourseID          INT,
    title             VARCHAR(100),
    last_active       TIME,
    forum_timestamp   DATETIME,
    forum_description VARCHAR(MAX),
    FOREIGN KEY (ModuleID, CourseID) REFERENCES Modules (ModuleID, CourseID) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE LearnerDiscussion
(
    ForumID         INT      NOT NULL,
    LearnerID       INT      NOT NULL,
    Post            VARCHAR(50),
    discussion_time DATETIME NOT NULL,
    PRIMARY KEY (ForumID, LearnerID, discussion_time),
    FOREIGN KEY (ForumID) REFERENCES Discussion_forum (forumID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE QuestReward
(
    RewardID    INT NOT NULL,
    QuestID     INT NOT NULL,
    LearnerID   INT NOT NULL,
    Time_earned DATETIME,
    PRIMARY KEY (RewardID, QuestID, LearnerID),

    FOREIGN KEY (RewardID) REFERENCES Reward (RewardID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (QuestID) REFERENCES Quest (QuestID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
);
