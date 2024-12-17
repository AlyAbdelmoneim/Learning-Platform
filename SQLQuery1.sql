--CREATE DATABASE ProjectDatabase7;
--USE ProjectDatabase7;


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
    ModuleID   INT IDENTITY(1, 1),
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
    FOREIGN KEY (LearnerID) REFERENCES Learner (LearnerID) ON DELETE CASCADE ON UPDATE CASCADE,
);

--ADMIN
--1)
GO
CREATE PROCEDURE ViewInfo
@LearnerID INT
AS
BEGIN 
    SELECT * FROM Learner
    WHERE LearnerID = @LearnerID
END

--2)
GO
CREATE PROCEDURE LearnerInfo
@LearnerID INT
AS
BEGIN 
    SELECT * FROM PersonalizationProfiles
    WHERE LearnerID = @LearnerID
END

--3)
GO
CREATE PROCEDURE EmotionalState
@LearnerID INT,
@Emotional_state VARCHAR(50) OUTPUT

AS
BEGIN 
    SELECT TOP 1 emotional_state FROM PersonalizationProfiles
    WHERE LearnerID = @LearnerID
END


--4)
GO
CREATE PROCEDURE LogDetails
@LearnerID INT
AS 
BEGIN
    SELECT * FROM Interaction_log
    WHERE LearnerID = @LearnerID
    ORDER BY interaction_Timestamp DESC
END


--5)
GO
CREATE PROCEDURE InstructorReview
@InstructorID INT
AS
BEGIN
    SELECT * FROM Pathreview
    WHERE InstructorID = @InstructorID
END

--6) added delete from courseprerequisite!!!!!!!!!!!!!!!!!!
go
CREATE PROCEDURE CourseRemove
@CourseID INT
AS
BEGIN
    -- Delete from CoursePrerequisite where the course is the prerequisite
    DELETE FROM CoursePrerequisite
    WHERE Prereq = @CourseID;

    -- Delete from CoursePrerequisite where the course is the course ID
    DELETE FROM CoursePrerequisite
    WHERE CourseID = @CourseID;

    -- Now delete from Course table
    DELETE FROM Course
    WHERE CourseID = @CourseID;
END
go

--7)
GO
CREATE PROCEDURE Highestgrade
AS
BEGIN
    SELECT CourseID, Title, total_marks
    FROM Assessments a1
    WHERE total_marks = (
        SELECT MAX(total_marks)
        FROM Assessments AS a2
        WHERE a2.CourseID = a1.CourseID
    )
END

--8) (is not running)
GO
CREATE PROCEDURE InstructorCount
AS
BEGIN
    SELECT CourseID , COUNT(InstructorID) AS InstructorCount
    FROM Teaches
    GROUP BY CourseID
    HAVING COUNT(InstructorID) > 1
END

--9)
GO
CREATE PROCEDURE ViewNot
@LearnerID INT
AS
BEGIN
    SELECT * FROM SystemNotification
    WHERE ID IN (
        SELECT NotificationID
        FROM ReceivedNotification
        WHERE LearnerID = @LearnerID
    )
END

--10)
GO
CREATE PROCEDURE CreateDiscussion
@ModuleID INT,
@CourseID INT,
@title VARCHAR(50),
@description VARCHAR(50)

AS
BEGIN
    INSERT INTO Discussion_forum(ModuleID, CourseID, title, forum_description)
    VALUES (@ModuleID, @CourseID, @title, @description)
    PRINT('Discussion forum created successfully')
END
SELECT * FROM Modules
EXEC CreateDiscussion @ModuleID = 12, @CourseID = 2, @title = 'Discussion 1', @description = 'Discussion about Module 1'

--11) added remove from achievment table
GO 
CREATE PROCEDURE RemoveBadge
@BadgeID INT
AS
BEGIN
    DELETE FROM Achievement
    WHERE BadgeID = @BadgeID;

    DELETE FROM Badge
    WHERE BadgeID = @BadgeID
END

--12)
GO
CREATE PROCEDURE CirteriaDelete
@criteria VARCHAR(50)
AS
BEGIN
    DELETE FROM Quest
    WHERE criteria = @criteria
END

--13)
GO
CREATE PROCEDURE NotificationUpdate
@LearnerID INT, 
@NotificationID INT,
@ReadStatus BIT

AS
BEGIN
    UPDATE SystemNotification
    SET ReadStatus = @ReadStatus
    WHERE ID = @NotificationID;
END

--14)
-- GO
-- CREATE PROCEDURE EmotionalTrendAnalysis
-- @CourseID INT,
-- @ModuleID INT, 
-- @TimePeriod DATETIME

-- AS
-- BEGIN
--     SELECT EF.LearnerID, EF.emotional_state, EF.feedback_timestamp
--     FROM Emotional_feedback EF
--     INNER JOIN Learning_activities LA ON EF.activityID = LA.ActivityID
--     WHERE LA.CourseID = @CourseID AND LA.ModuleID = @ModuleID AND EF.feedback_timestamp >= @TimePeriod AND EF.feedback_timestamp <= GETDATE();
-- END
--END ADMIN

--lEARNER
--1
GO
CREATE PROCEDURE ProfileUpdate
    @learnerID INT,
    @profileID INT,
    @PreferredContentType VARCHAR(50),
    @emotional_state VARCHAR(50),
    @PersonalityType VARCHAR(50)
AS
BEGIN
    UPDATE PersonalizationProfiles
    SET 
        Prefered_content_type = @PreferredContentType,
        emotional_state = @emotional_state,
        personality_type = @PersonalityType
    WHERE 
        LearnerID = @learnerID AND ProfileID = @profileID;
END;
GO

--2 (NOT SURE)
GO
CREATE PROCEDURE TotalPoints
    @LearnerID INT,
    @RewardType VARCHAR(50),
    @TotalPoints INT OUTPUT
AS
BEGIN
    -- Calculate the total points based on the learner ID and reward type
    SELECT @TotalPoints = SUM(R.reward_value)
    FROM Reward R
    INNER JOIN QuestReward QR ON R.RewardID = QR.RewardID 
    INNER JOIN Learner L ON QR.LearnerID = L.LearnerID 
    WHERE L.LearnerID = @LearnerID AND R.reward_type = @RewardType;

    -- If no rewards are found, set the output to 0
    IF @TotalPoints IS NULL
        SET @TotalPoints = 0;
END;
GO

--3 (NOT SURE ABOUT STATUS)
DROP PROCEDURE IF EXISTS EnrolledCourses;
GO
CREATE PROCEDURE EnrolledCourses
    @LearnerID INT
AS
BEGIN
    SELECT c.CourseID, c.Title, c.course_description, c.credit_points, c.difficulty_level, c.learning_objective
    FROM Course_enrollment e
    INNER JOIN Course c ON e.CourseID = c.CourseID
    WHERE e.LearnerID = @LearnerID AND e.enrollment_status <> 'completed'
END;
GO


GO
CREATE PROCEDURE Prerequisites
    @LearnerID INT,
    @CourseID INT
AS
BEGIN
    -- Check if the learner has completed all prerequisites for the course
    IF NOT EXISTS (
        SELECT Prereq
        FROM CoursePrerequisite
        WHERE CourseID = @CourseID
          AND Prereq NOT IN (
              SELECT CourseID
              FROM Course_enrollment
              WHERE LearnerID = @LearnerID
          )
    )
    BEGIN
        PRINT 'All prerequisites are completed.';
    END
    ELSE
    BEGIN
        PRINT 'Not all prerequisites are completed.';
    END
END;
GO

--5
GO
CREATE PROCEDURE ModuleTraits
    @TargetTrait VARCHAR(50),
    @CourseID INT
AS
BEGIN
    SELECT m.ModuleID, m.Title
    FROM Modules m
    INNER JOIN Target_traits mt ON m.ModuleID = mt.ModuleID
    WHERE m.CourseID = @CourseID
      AND mt.Trait = @TargetTrait;
END;
GO

--6
DROP PROCEDURE IF EXISTS LeaderboardRank;
GO
CREATE PROCEDURE LeaderboardRank
    @LeaderboardID INT
AS
BEGIN
    SELECT 
        BoardID,
        LearnerID,
        rankNum,
        total_points
    FROM Ranking
    WHERE BoardID = @LeaderboardID
    ORDER BY rankNum;
END;
GO

-- SELECT * FROM LeaderboardRank

--7
GO
CREATE PROCEDURE ActivityEmotionalFeedback
    @ActivityID INT,
    @LearnerID INT,
    @timestamp TIME,
    @emotionalstate VARCHAR(50)
AS
BEGIN
    INSERT INTO Emotional_feedback (LearnerID, activityID,feedback_timestamp ,emotional_state)
    VALUES (@LearnerID, @ActivityID, @timestamp, @emotionalstate);
END;
GO


--8
GO
CREATE PROCEDURE JoinQuest
    @LearnerID INT,
    @QuestID INT
AS
BEGIN
    DECLARE @maxParticipants INT;
    DECLARE @currentParticipants INT;

    SELECT @maxParticipants = max_num_participants
    FROM Collaborative
    WHERE QuestID = @QuestID;

    SELECT @currentParticipants = COUNT(*)
    FROM LearnersCollaboration
    WHERE QuestID = @QuestID;

    IF @currentParticipants < @maxParticipants
    BEGIN
        INSERT INTO LearnersCollaboration (LearnerID, QuestID, completion_status)
        VALUES (@LearnerID, @QuestID, 'In Progress');
        PRINT 'You have successfully joined the quest.';
    END
    ELSE
    BEGIN
        PRINT 'The quest is full. You cannot join at this time.';
    END
END;
GO

--9
GO
CREATE PROCEDURE SkillsProficiency
    @LearnerID INT
AS
BEGIN
    SELECT skill_name, proficiency_level
    FROM SkillProgression
    WHERE LearnerID = @LearnerID;
END;
GO

--10
GO
CREATE PROCEDURE ViewScore
    @LearnerID INT,
    @AssessmentID INT,
    @score INT OUTPUT
AS
BEGIN
    SELECT @score = scoredPoint
    FROM Takenassessment
    WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID;

    IF @score IS NULL
        SET @score = 0;
END;
GO

--11
GO
CREATE PROCEDURE AssessmentsList
    @courseID INT,
    @ModuleID INT,
    @LearnerID INT
AS
BEGIN
    SELECT a.ID, a.title, ta.scoredPoint
    FROM Assessments a
    INNER JOIN Takenassessment ta ON ta.AssessmentID = a.ID
    WHERE a.ModuleID = @ModuleID AND a.CourseID = @courseID AND ta.LearnerID = @LearnerID 
END;
GO

--12
GO
CREATE PROCEDURE Courseregister
    @LearnerID INT,
    @CourseID INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT Prereq
        FROM CoursePrerequisite
        WHERE CourseID = @CourseID
          AND Prereq NOT IN (
              SELECT CourseID
              FROM Course_enrollment
              WHERE LearnerID = @LearnerID
          )
    )
    BEGIN
        INSERT INTO Course_enrollment (CourseID, LearnerID, enrollment_date, enrollment_status)
        VALUES (@CourseID, @LearnerID, GETDATE(), 'Enrolled');
        PRINT 'You have successfully registered for the course.';
    END
    ELSE
    BEGIN
        PRINT 'You have not completed all prerequisites for this course.';
    END
END;
GO

--13

CREATE PROCEDURE Post
    @LearnerID INT,
    @DiscussionID INT,
    @Post VARCHAR(MAX)
AS
BEGIN
    INSERT INTO LearnerDiscussion (ForumID, LearnerID, Post, discussion_time)
    VALUES (@DiscussionID, @LearnerID, @Post , GETDATE());
END;
GO

--14
GO
CREATE PROCEDURE AddGoal
    @LearnerID INT,
    @GoalID INT
AS
BEGIN
    INSERT INTO LearnersGoals (GoalID, LearnerID)
    VALUES (@GoalID, @LearnerID);
END;
GO

--15
GO
CREATE PROCEDURE CurrentPath
    @LearnerID INT,
    @ProfileID INT
AS
BEGIN
    SELECT pathID, completion_status, custom_content, adaptive_rules, LearnerID, ProfileID
    FROM Learning_path
    WHERE LearnerID = @LearnerID AND ProfileID = @ProfileID;
END;
GO

--16
GO 
create procedure QuestMembers
    @LearnerID int
AS
BEGIN
    with myCollabQuests as (
        select lc.QuestID
        from LearnersCollaboration lc
        inner join Collaborative c on lc.QuestID = c.QuestID
        where lc.LearnerID = @LearnerID and c.deadline > getdate()
    )

    select lc.LearnerID, lc.QuestID
    from LearnersCollaboration lc
    inner join myCollabQuests mcq on lc.QuestID = mcq.QuestID
END

--17
GO
CREATE PROCEDURE QuestProgress
    @LearnerID INT
AS
BEGIN
    -- Select data from LearnersMastery
    SELECT QuestID, completion_status
    FROM LearnersMastery
    WHERE LearnerID = @LearnerID

    UNION

    -- Select data from LearnersCollaboration
    SELECT QuestID, completion_status
    FROM LearnersCollaboration
    WHERE LearnerID = @LearnerID
END;
GO

--18
GO
CREATE PROCEDURE GoalReminder
    @LearnerID INT
AS 
BEGIN
    INSERT INTO SystemNotification (notification_message, urgency_level, ReadStatus)
    SELECT CONCAT('Goal "', goal_description, '" is due on ', deadline), 'High', 0
    FROM (
        SELECT goal_description, deadline
        FROM Learning_goal 
        WHERE DATEDIFF(DAY, deadline, GETDATE()) <= 3 AND ID IN (
            SELECT GoalID
            FROM LearnersGoals
            WHERE LearnerID = @LearnerID
        )
    ) AS due_goals;

    INSERT INTO ReceivedNotification (NotificationID, LearnerID)
    SELECT SCOPE_IDENTITY(), @LearnerID
    FROM (
        SELECT goal_description, deadline
        FROM Learning_goal 
        WHERE DATEDIFF(DAY, deadline, GETDATE()) <= 3 AND ID IN (
            SELECT GoalID
            FROM LearnersGoals
            WHERE LearnerID = @LearnerID
        )
    ) AS due_goals;
    PRINT 'Goal reminders have been sent.';
END;

--19
GO
CREATE PROCEDURE SkillProgressHistory
    @LearnerID INT,
    @Skill VARCHAR(50)
AS
BEGIN
    SELECT skillProgression_timestamp, proficiency_level
    FROM SkillProgression
    WHERE LearnerID = @LearnerID AND skill_name = @Skill
    ORDER BY skillProgression_timestamp;
END;
GO

--20
--- double check this one, what does score breakdowns even mean?
GO
CREATE PROCEDURE AssessmentAnalysis
    @LearnerID INT
AS
BEGIN
    SELECT AssessmentID, scoredPoint
    FROM Takenassessment 
    WHERE LearnerID = @LearnerID;
END;
GO

--21
GO
CREATE PROCEDURE LeaderboardFilter
    @LearnerID INT
AS
BEGIN
    SELECT BoardID, rankNum, total_points
    FROM Ranking
    WHERE LearnerID = @LearnerID
    ORDER BY rankNum DESC;
END;
GO

-- End of learner

--INSTRUCTOR

--1)
GO 
CREATE PROCEDURE SkillLearners
@Skillname VARCHAR(50)
AS
BEGIN
    SELECT L.LearnerID, L.first_name, L.last_name
    FROM Learner L
    INNER JOIN Skills S ON L.LearnerID = S.LearnerID
    WHERE S.skill = @Skillname
END;
GO 

--2)
GO 
CREATE PROCEDURE NewActivity
@CourseID int, @ModuleID int, @activitytype varchar(50), @instructiondetails varchar(max), @maxpoints int
AS
BEGIN
    INSERT INTO Learning_activities(ModuleID, CourseID, activity_type, instruction_details, Max_points)
    VALUES (@ModuleID, @CourseID, @activitytype, @instructiondetails, @maxpoints)
END;
GO

--3)
GO 
CREATE PROCEDURE NewAchievement
@LearnerID int, @BadgeID int, @description varchar(MAX), @date_earned date, @type varchar(50)
AS
BEGIN
    INSERT INTO Achievement(LearnerID, BadgeID, achievement_description, date_earned, achievement_type)
    VALUES (@LearnerID, @BadgeID, @description, @date_earned, @type)
END;
GO

--4)
GO 
CREATE PROCEDURE LearnerBadge
@BadgeID INT
AS
BEGIN
    SELECT L.LearnerID, L.first_name, L.last_name
    FROM Learner L
    INNER JOIN Achievement A ON L.LearnerID = A.LearnerID
    WHERE A.BadgeID = @BadgeID
END;

--5)

GO 
CREATE PROCEDURE NewPath
@LearnerID INT, @ProfileID INT, @completion_status varchar(50), @custom_content varchar(max), @adaptiverules varchar(max)
AS
BEGIN
    INSERT INTO Learning_path(LearnerID, ProfileID, completion_status, custom_content, adaptive_rules)
    VALUES (@LearnerID, @ProfileID, @completion_status, @custom_content, @adaptiverules)
END;
GO

--6)
GO
CREATE PROCEDURE TakenCourses
@LearnerID INT
AS
BEGIN
    SELECT C.CourseID, C.Title
    FROM Course C
    INNER JOIN Course_enrollment E ON C.CourseID = E.CourseID
    WHERE E.LearnerID = @LearnerID
END;

--7)
GO
CREATE PROCEDURE CollaborativeQuest
@difficulty_level varchar(50),
@criteria varchar(50), 
@quest_description varchar(50), 
@title varchar(100), 
@Maxnumparticipants int, 
@deadline datetime

AS
BEGIN
    INSERT INTO Quest(difficulty_level, criteria, quest_description, title)
    VALUES (@difficulty_level, @criteria, @quest_description, @title)

    DECLARE @QuestID INT = SCOPE_IDENTITY()

    INSERT INTO Collaborative(QuestID, max_num_participants, deadline)
    VALUES (@QuestID, @Maxnumparticipants, @deadline)
END;
GO

GO
CREATE PROCEDURE SkillMasteryQuest
@difficulty_level varchar(50),
@criteria varchar(50),
@quest_description varchar(50),
@title varchar(100),
@skill varchar(50)

AS
BEGIN
    INSERT INTO Quest(difficulty_level, criteria, quest_description, title)
    VALUES (@difficulty_level, @criteria, @quest_description, @title)

    DECLARE @QuestID INT = SCOPE_IDENTITY()

    INSERT INTO Skill_Mastery(QuestID, skill)
    VALUES (@QuestID, @skill)
END;

--8)
GO 
CREATE PROCEDURE DeadlineUpdate
@QuestID INT, @deadline DATETIME2
AS
BEGIN
    UPDATE Collaborative
    SET deadline = @deadline
    WHERE QuestID = @QuestID
END;
GO 

--9)
GO 
CREATE PROCEDURE GradeUpdate
@LearnerID INT, @AssessmentID INT, @points INT
AS
BEGIN
    UPDATE Takenassessment
    SET scoredPoint = @points
    WHERE LearnerID = @LearnerID AND AssessmentID = @AssessmentID
END;
GO

--10)
GO
CREATE PROCEDURE AssessmentNot
@NotificationID INT, 
@timestamp DATETIME,
@message VARCHAR(MAX),
@urgencylevel VARCHAR(50),
@LearnerID INT

AS
BEGIN
    INSERT INTO SystemNotification(ID, notification_message, urgency_level, ReadStatus)
    VALUES (@NotificationID, @message, @urgencylevel, 0)

    INSERT INTO ReceivedNotification(NotificationID, LearnerID)
    VALUES (@NotificationID, @LearnerID)
END;
GO
SELECT * FROM Learner
--11)
GO
CREATE PROCEDURE NewGoal
@GoalID INT, 
@status VARCHAR(MAX),
@deadline DATE,
@description VARCHAR(MAX)

AS
BEGIN
    INSERT INTO Learning_goal(ID, goal_status, deadline, goal_description)
    VALUES (@GoalID, @status, @deadline, @description)
END;
GO

--12)
GO 
CREATE PROCEDURE LearnersCourses
@CourseID INT, 
@InstructorID INT

AS
BEGIN
    SELECT L.LearnerID, L.first_name, L.last_name
    FROM Learner L
    INNER JOIN Course_enrollment E ON L.LearnerID = E.LearnerID
    INNER JOIN Teaches T ON E.CourseID = T.CourseID
    WHERE T.InstructorID = @InstructorID AND E.CourseID = @CourseID
END;
GO

--13)
GO
CREATE PROCEDURE LastActive
@ForumID INT,
@lastactive DATETIME OUTPUT

AS
BEGIN
    SELECT @lastactive = last_active
    FROM Discussion_forum
    WHERE forumID = @ForumID
END;
GO

--14)
GO
CREATE PROCEDURE CommonEmotionalState
@state VARCHAR(50) OUTPUT
AS 
BEGIN
    SELECT TOP 1 @state = emotional_state
    FROM Emotional_feedback
    GROUP BY emotional_state
    ORDER BY COUNT(emotional_state) DESC
END;
GO

--15)

GO
CREATE PROCEDURE ModuleDifficulty
@CourseID INT
AS
BEGIN
    SELECT *
    FROM Modules M
    WHERE M.CourseID = @CourseID
    ORDER BY M.difficulty
END;
GO 

--16)
GO
CREATE PROCEDURE Proficiencylevel
@LearnerID INT,
@skill VARCHAR(50) OUTPUT

AS 
BEGIN
    SELECT TOP 1 @skill = proficiency_level
    FROM SkillProgression
    WHERE LearnerID = @LearnerID
    ORDER BY proficiency_level DESC
END;
GO

--17)

GO
CREATE PROCEDURE ProficiencyUpdate
    @Skill VARCHAR(50),
    @LearnerID INT,
    @Level VARCHAR(50)
AS
BEGIN
    UPDATE SkillProgression
    SET proficiency_level = @Level
    WHERE LearnerID = @LearnerID AND skill_name = @Skill;
END;
GO

--18)
GO 
CREATE PROCEDURE LeastBadge
@LearnerID INT OUTPUT
AS
BEGIN
    SELECT TOP 1 @LearnerID = LearnerID
    FROM Achievement
    GROUP BY LearnerID
    ORDER BY COUNT(BadgeID) ASC    
END;
GO

--19)
GO 
CREATE PROCEDURE PreferedType
@type VARCHAR(50) OUTPUT
AS
BEGIN
    SELECT TOP 1 @type = Prefered_content_type
    FROM PersonalizationProfiles
    GROUP BY Prefered_content_type
    ORDER BY COUNT(Prefered_content_type) DESC
END;
GO

--20)
GO
CREATE PROCEDURE AssessmentAnalytics
@CourseID INT,
@ModuleID INT
AS
BEGIN
    SELECT assessmentID , AVG(scoredPoint) as avgScore
    FROM Takenassessment 
    GROUP BY assessmentID
    HAVING assessmentID IN (
        SELECT ID
        FROM Assessments
        WHERE CourseID = @CourseID AND ModuleID = @ModuleID
    )
END;
GO

--21)
GO
CREATE PROCEDURE EmotionalTrendAnalysisIns
AS
BEGIN
    SELECT 
        EF.FeedbackID,       -- Required for Emotional_feedback model
        EF.LearnerID,        -- Required for Emotional_feedback model
        EF.activityID,       -- Required for Emotional_feedback model
        EF.feedback_timestamp,
        EF.emotional_state
    FROM Emotional_feedback EF
    INNER JOIN Learning_activities LA ON EF.activityID = LA.ActivityID
    INNER JOIN Teaches T ON LA.CourseID = T.CourseID;
END;
GO

GO 
CREATE PROCEDURE MyGoals
@LearnerID INT
AS
BEGIN
    SELECT ID, goal_description, deadline, goal_status
    FROM Learning_goal
    WHERE ID IN (
        SELECT GoalID
        FROM LearnersGoals
        WHERE LearnerID = @LearnerID
    )
END;




GO
CREATE PROCEDURE CreateAndAssignGoal
    @LearnerID INT,
    @GoalStatus VARCHAR(MAX),
    @Deadline DATE,
    @GoalDescription VARCHAR(MAX)
AS
BEGIN
    DECLARE @NewGoalID INT;

    -- Step 1: Create a new goal using the NewGoal procedure
    -- Generate a new GoalID (you can modify this if you have a specific way of generating the ID)
    SET @NewGoalID = (SELECT ISNULL(MAX(ID), 0) + 1 FROM Learning_goal); -- You can adjust this logic for ID generation
    
    EXEC NewGoal @GoalID = @NewGoalID, @status = @GoalStatus, @deadline = @Deadline, @description = @GoalDescription;

    -- Step 2: Assign the newly created goal to the learner using the AddGoal procedure
    EXEC AddGoal @LearnerID = @LearnerID, @GoalID = @NewGoalID;
    
    PRINT 'Goal Created and Assigned Successfully';
END;
GO


GO

CREATE PROCEDURE GetModulesForCourse
    @CourseID INT
AS
BEGIN
    SELECT ModuleID, CourseID, Title, difficulty, contentURL
    FROM Modules
    WHERE CourseID = @CourseID;
END;
GO



CREATE PROCEDURE GetDiscussionForums
    @CourseID INT,
    @ModuleID INT
AS
BEGIN
    SELECT ForumID, ModuleID, CourseID, title, forum_description, forum_timestamp, last_active
    FROM Discussion_forum
    WHERE ModuleID = @ModuleID AND CourseID = @CourseID;
END;


GO
CREATE PROCEDURE GetPostsForForum
    @ForumID INT
AS
BEGIN
    SELECT ForumID, LearnerID, Post, discussion_time
    FROM LearnerDiscussion
    WHERE ForumID = @ForumID;
END;


GO 
CREATE PROCEDURE InstructorCourses
@InstructorID INT
AS
BEGIN
    SELECT C.CourseID, C.Title, C.course_description, C.credit_points, C.difficulty_level, C.learning_objective
    FROM Course C
    INNER JOIN Teaches T ON C.CourseID = T.CourseID
    WHERE T.InstructorID = @InstructorID
END;


GO
CREATE PROCEDURE GetAllCourses
AS
BEGIN
    SELECT CourseID, Title, course_description, credit_points, difficulty_level, learning_objective
    FROM Course;
END;

GO 
CREATE PROCEDURE GetAllCollaborativeQuests
AS
BEGIN
    SELECT Q.QuestID, Q.difficulty_level, Q.criteria, Q.quest_description, Q.title, C.max_num_participants, C.deadline
    FROM Quest Q
    INNER JOIN Collaborative C ON Q.QuestID = C.QuestID;
END;



GO
CREATE PROCEDURE GetAllSkillMasteryQuests
AS
BEGIN
    SELECT Q.QuestID, Q.difficulty_level, Q.criteria, Q.quest_description, Q.title, SM.skill
    FROM Quest Q
    INNER JOIN Skill_Mastery SM ON Q.QuestID = SM.QuestID;
END;




GO
CREATE PROCEDURE GetNotifications
    @LearnerID INT
AS
BEGIN
    SELECT N.ID, N.notification_message, N.urgency_level, N.ReadStatus, N.notification_timestamp
    FROM SystemNotification N
    INNER JOIN ReceivedNotification R ON N.ID = R.NotificationID
    WHERE R.LearnerID = @LearnerID;
END;

GO 
CREATE PROCEDURE GetAllAchievements
AS
BEGIN
    SELECT A.AchievementID, A.LearnerID, A.BadgeID, A.achievement_description, A.date_earned, A.achievement_type
    FROM Achievement A;
END;




GO
CREATE PROCEDURE SendNotification
    @LearnerID INT,
    @Message VARCHAR(MAX),
    @UrgencyLevel VARCHAR(50)
AS
BEGIN
    DECLARE @NotificationID INT;

    -- Insert new notification into SystemNotification table
    -- Get the highest ID from SystemNotification and add one
    DECLARE @NewNotificationID INT;
    SELECT @NewNotificationID = ISNULL(MAX(ID), 0) + 1 FROM SystemNotification;
    INSERT INTO SystemNotification (ID, notification_timestamp, notification_message, urgency_level, ReadStatus)
    VALUES (@NewNotificationID, GETDATE(), @Message, @UrgencyLevel, 0);

    -- Get the ID of the newly inserted notification
    -- Insert into ReceivedNotification table
    INSERT INTO ReceivedNotification (NotificationID, LearnerID)
    VALUES (@NewNotificationID, @LearnerID);
END;
GO

GO
CREATE PROCEDURE GetColleaguesInQuest
    @LearnerID INT,
    @QuestID INT
AS
BEGIN
    SELECT L.LearnerID, L.first_name, L.last_name, L.email, L.adminPassword, L.birth_date, L.gender, L.country, L.cultural_background
    FROM Learner L
    INNER JOIN LearnersCollaboration LC ON L.LearnerID = LC.LearnerID
    WHERE LC.QuestID = @QuestID AND LC.LearnerID <> @LearnerID;
END;
GO

CREATE PROCEDURE GetLearnerCollaborativeQuests
    @LearnerID INT
AS
BEGIN
    SELECT Q.QuestID, Q.difficulty_level, Q.criteria, Q.quest_description, Q.title, C.max_num_participants, C.deadline
    FROM Quest Q
    INNER JOIN Collaborative C ON Q.QuestID = C.QuestID
    WHERE Q.QuestID IN (
        SELECT QuestID
        FROM LearnersCollaboration
        WHERE LearnerID = @LearnerID
    );
END;

GO
CREATE PROCEDURE AddNewModule
    @CourseID INT,
    @Title VARCHAR(100),
    @Difficulty VARCHAR(50),
    @ContentURL VARCHAR(255),
    @Trait VARCHAR(50),
    @ContentType VARCHAR(50)
AS
BEGIN
    DECLARE @ModuleID INT;

    -- Insert into Modules table
    INSERT INTO Modules (CourseID, Title, difficulty, contentURL)
    VALUES (@CourseID, @Title, @Difficulty, @ContentURL);

    -- Get the newly inserted ModuleID
    SET @ModuleID = SCOPE_IDENTITY();

    -- Insert into Target_traits table
    INSERT INTO Target_traits (ModuleID, CourseID, Trait)
    VALUES (@ModuleID, @CourseID, @Trait);

    -- Insert into ModuleContent table
    INSERT INTO ModuleContent (ModuleID, CourseID, content_type)
    VALUES (@ModuleID, @CourseID, @ContentType);

    PRINT 'New module added successfully';
END;
GO

GO
CREATE PROCEDURE ViewAllNotifications
AS
BEGIN
    SELECT ID, notification_timestamp, notification_message, urgency_level, ReadStatus
    FROM SystemNotification
    ORDER BY notification_timestamp DESC;
END;


SELECT * FROM Learner

GO
CREATE PROCEDURE CompletedCourses
    @LearnerID INT
AS
BEGIN
    SELECT c.CourseID, c.Title, c.course_description, c.credit_points, c.difficulty_level, c.learning_objective
    FROM Course_enrollment e
    INNER JOIN Course c ON e.CourseID = c.CourseID
    WHERE e.LearnerID = @LearnerID AND e.enrollment_status = 'completed'
END;
GO

SELECT * FROM Badge
GO
CREATE PROCEDURE AssessmentListModified
    @LearnerID INT,
    @CourseID INT,
    @ModuleID INT
AS
BEGIN
    SELECT a.ID AS AssessmentID, ta.scoredPoint
    FROM Assessments a
    LEFT JOIN Takenassessment ta ON a.ID = ta.AssessmentID AND ta.LearnerID = @LearnerID
    WHERE a.CourseID = @CourseID AND a.ModuleID = @ModuleID;
END;
GO



GO 
CREATE PROCEDURE GetActivities
    @CourseID INT,
    @ModuleID INT
AS
BEGIN
    SELECT activityID, CourseID, ModuleID, activity_type, instruction_details, Max_points
    FROM Learning_activities
    WHERE CourseID = @CourseID AND ModuleID = @ModuleID;
END;
GO

GO
CREATE PROCEDURE EmotionalTrendAnalysis
AS
BEGIN
    SELECT 
        EF.FeedbackID,        -- Include FeedbackID
        EF.LearnerID,         -- Include LearnerID
        EF.activityID,        -- Ensure activityID is included
        EF.feedback_timestamp,
        EF.emotional_state,
        LA.CourseID, 
        LA.ModuleID
    FROM 
        Emotional_feedback EF
    INNER JOIN 
        Learning_activities LA 
    ON 
        EF.activityID = LA.ActivityID;
END
GO

--DROP PROCEDURE GetAvailableCourses
--NEW PROCEDURES
GO
CREATE PROCEDURE GetAvailableCourses
    @LearnerID INT
AS
BEGIN
    SELECT *
    FROM Course c
    WHERE c.CourseID NOT IN (
        SELECT ce.CourseID
        FROM Course_enrollment ce
        WHERE ce.LearnerID = @LearnerID
    );
END
GO

GO
CREATE PROCEDURE EnrollLearnerInCourse
    @LearnerID INT,
    @CourseID INT
AS
BEGIN
    INSERT INTO Course_enrollment (LearnerID, CourseID, enrollment_date)
    VALUES (@LearnerID, @CourseID, GETDATE());
END
GO


GO
CREATE PROCEDURE CheckCourseEnrollment
    @CourseID INT,
    @HasEnrollments BIT OUTPUT
AS
BEGIN
    SELECT @HasEnrollments = CASE 
        WHEN EXISTS (
            SELECT 1 
            FROM Course_enrollment 
            WHERE CourseID = @CourseID
        ) THEN 1
        ELSE 0
    END
END
GO


GO
CREATE PROCEDURE GetLearnersWithCompletedPrerequisites
    @CourseID INT
AS
BEGIN
    -- Get the list of learners who have completed all prerequisites for the course
    SELECT DISTINCT ce.LearnerID, l.first_name , l.last_name 
    FROM Course_enrollment ce
    JOIN Learner l ON ce.LearnerID = l.LearnerID
    WHERE NOT EXISTS (
        SELECT 1
        FROM CoursePrerequisite cp
        WHERE cp.CourseID = @CourseID
        AND cp.Prereq NOT IN (
            SELECT CourseID
            FROM Course_enrollment
            WHERE LearnerID = ce.LearnerID
        )
    )
END;
GO













INSERT INTO Course (CourseID,Title, learning_objective, credit_points, difficulty_level, course_description)
VALUES
    (1, 'Math 101', 'Basic Math', 3, 'Easy', 'Introduction to basic math concepts'),
    (2, 'Science 101', 'Basic Science', 3, 'Easy', 'Introduction to basic science concepts'),
    (3, 'History 101', 'Basic History', 3, 'Easy', 'Introduction to basic history concepts'),
    (4, 'Math 102', 'Intermediate Math', 4, 'Medium', 'Intermediate math concepts'),
    (5, 'Science 102', 'Intermediate Science', 4, 'Medium', 'Intermediate science concepts'),
    (6, 'History 102', 'Intermediate History', 4, 'Medium', 'Intermediate history concepts'),
    (7,'Math 103', 'Advanced Math', 5, 'Hard', 'Advanced math concepts'),
    (8, 'Science 103', 'Advanced Science', 5, 'Hard', 'Advanced science concepts'),
    (9, 'History 103', 'Advanced History', 5, 'Hard', 'Advanced history concepts'),
    (10,'Math 104', 'Expert Math', 6, 'Very Hard', 'Expert level math concepts');

SELECT *
FROM Course_enrollment

SELECT *
FROM Learner

SELECT * 
FROM Course

SELECT *
FROM Instructor

EXEC InstructorCourses @InstructorID = 1;


INSERT INTO Course_enrollment (CourseID, LearnerID, completion_date, enrollment_date, enrollment_status)
VALUES 
(1, 1, '2024-12-01', '2024-09-01', 'Completed'),
(1, 2, NULL, '2024-10-15', 'In Progress'),
(3, 2, '2024-11-20', '2024-08-20', 'Completed'),
(3, 3, NULL, '2024-11-01', 'Enrolled'),
(105, 205, '2024-10-30', '2024-06-30', 'Completed'),
(106, 206, NULL, '2024-12-10', 'Pending'),
(107, 207, '2024-11-25', '2024-07-15', 'Completed'),
(108, 208, NULL, '2024-09-10', 'Dropped'),
(109, 209, '2024-12-05', '2024-09-05', 'Completed'),
(110, 210, NULL, '2024-10-01', 'In Progress');


SELECT *
FROM Instructor

INSERT INTO Teaches (InstructorID, CourseID)
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10);


-- Inserting sample course prerequisites
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (101, 100); -- Course 101 requires Course 100 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (102, 100); -- Course 102 requires Course 100 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (103, 101); -- Course 103 requires Course 101 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (104, 102); -- Course 104 requires Course 102 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (105, 103); -- Course 105 requires Course 103 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (106, 104); -- Course 106 requires Course 104 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (107, 105); -- Course 107 requires Course 105 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (108, 106); -- Course 108 requires Course 106 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (109, 107); -- Course 109 requires Course 107 as a prerequisite
INSERT INTO CoursePrerequisite (CourseID, Prereq) VALUES (110, 108); -- Course 110 requires Course 108 as a prerequisite


