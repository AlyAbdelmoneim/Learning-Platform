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
GO
CREATE PROCEDURE EmotionalTrendAnalysis
@CourseID INT,
@ModuleID INT, 
@TimePeriod DATETIME

AS
BEGIN
    SELECT EF.LearnerID, EF.emotional_state, EF.feedback_timestamp
    FROM Emotional_feedback EF
    INNER JOIN Learning_activities LA ON EF.activityID = LA.ActivityID
    WHERE LA.CourseID = @CourseID AND LA.ModuleID = @ModuleID AND EF.feedback_timestamp >= @TimePeriod AND EF.feedback_timestamp <= GETDATE();
END
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
GO
CREATE PROCEDURE EnrolledCourses
    @LearnerID INT
AS
BEGIN
    SELECT c.CourseID, c.Title
    FROM Course_enrollment e
    INNER JOIN Course c ON e.CourseID = c.CourseID
    WHERE e.LearnerID = @LearnerID
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
GO
CREATE PROCEDURE LeaderboardRank
    @LeaderboardID INT
AS
BEGIN
    SELECT LearnerID, rankNum, total_points
    FROM Ranking
    WHERE BoardID = @LeaderboardID
    ORDER BY rankNum;
END;
GO

--7
DROP PROCEDURE IF EXISTS ViewMyDeviceCharge;
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
    @LearnerID INT
AS
BEGIN
    SELECT pathID, completion_status
    FROM Learning_path
    WHERE LearnerID = @LearnerID;
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

    UNION

    -- Select data from Achievement
    SELECT AchievementID AS QuestID, BadgeID AS completion_status
    FROM Achievement
    WHERE LearnerID = @LearnerID;
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

--8)
GO 
CREATE PROCEDURE DeadlineUpdate
@QuestID INT, @deadline DATETIME
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

--11)
GO
CREATE PROCEDURE NewGoal
@GoalID INT, 
@status VARCHAR(MAX),
@deadline DATETIME,
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
    @CourseID INT,
    @ModuleID INT,
    @TimePeriod DATETIME
AS
BEGIN
    SELECT EF.LearnerID, EF.emotional_state, EF.feedback_timestamp
    FROM Emotional_feedback EF
    INNER JOIN Learning_activities LA ON EF.activityID = LA.ActivityID
    INNER JOIN Teaches T ON LA.CourseID = T.CourseID
    WHERE LA.CourseID = @CourseID 
      AND LA.ModuleID = @ModuleID 
      AND EF.feedback_timestamp >= @TimePeriod 
      AND EF.feedback_timestamp <= GETDATE()
END;

