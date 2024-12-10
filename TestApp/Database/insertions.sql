INSERT INTO Learner (LearnerID, first_name, last_name, gender, birth_date, country, cultural_background)
VALUES
    (1, 'John', 'Doe', 'M', '1990-01-01', 'USA', 'American'),
    (2, 'Jane', 'Smith', 'F', '1992-02-02', 'Canada', 'Canadian'),
    (3, 'Alice', 'Johnson', 'F', '1988-03-03', 'UK', 'British'),
    (4, 'Bob', 'Brown', 'M', '1991-04-04', 'Australia', 'Australian'),
    (5, 'Charlie', 'Davis', 'M', '1993-05-05', 'New Zealand', 'Kiwi'),
    (6,'Diana', 'Evans', 'F', '1989-06-06', 'Ireland', 'Irish'),
    (7, 'Eve', 'Wilson', 'F', '1994-07-07', 'South Africa', 'South African'),
    (8, 'Frank', 'Garcia', 'M', '1990-08-08', 'Spain', 'Spanish'),
    (9, 'Grace', 'Martinez', 'F', '1992-09-09', 'Mexico', 'Mexican'),
    (10, 'Hank', 'Lee', 'M', '1988-10-10', 'China', 'Chinese');

INSERT INTO Skills (LearnerID, skill)
VALUES
    (1, 'Python'),
    (2, 'Java'),
    (3, 'SQL'),
    (4, 'JavaScript'),
    (5, 'C++'),
    (6, 'HTML'),
    (7, 'CSS'),
    (8, 'Ruby'),
    (9, 'PHP'),
    (10, 'Swift');

INSERT INTO LearningPreference (LearnerID, preference)
VALUES
    (1, 'Visual'),
    (2, 'Auditory'),
    (3, 'Kinesthetic'),
    (4, 'Reading/Writing'),
    (5, 'Visual'),
    (6, 'Auditory'),
    (7, 'Kinesthetic'),
    (8, 'Reading/Writing'),
    (9, 'Visual'),
    (10, 'Auditory');

INSERT INTO PersonalizationProfiles (ProfileID, LearnerID, Prefered_content_type, emotional_state, personality_type)
VALUES
    (1,1, 'Video', 'Happy', 'Introvert'),
    (2,2, 'Text', 'Neutral', 'Extrovert'),
    (3,3, 'Audio', 'Sad', 'Ambivert'),
    (4,4, 'Video', 'Happy', 'Introvert'),
    (5,5, 'Text', 'Neutral', 'Extrovert'),
    (6,6, 'Audio', 'Sad', 'Ambivert'),
    (7,7, 'Video', 'Happy', 'Introvert'),
    (8,8, 'Text', 'Neutral', 'Extrovert'),
    (9,9, 'Audio', 'Sad', 'Ambivert'),
    (10,10, 'Video', 'Happy', 'Introvert');

INSERT INTO HealthCondition (LearnerID, ProfileID, condition)
VALUES
    (1, 1, 'Asthma'),
    (2, 2, 'Diabetes'),
    (3, 3, 'Hypertension'),
    (4, 4, 'Asthma'),
    (5, 5, 'Diabetes'),
    (6, 6, 'Hypertension'),
    (7, 7, 'Asthma'),
    (8, 8, 'Diabetes'),
    (9, 9, 'Hypertension'),
    (10, 10, 'Asthma');

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

INSERT INTO CoursePrerequisite (CourseID, Prereq)
VALUES
    (4, 1),
    (5, 2),
    (6, 3),
    (7, 4),
    (8, 5),
    (9, 6),
    (10, 7),
    (10, 8),
    (10, 9),
    (9, 4);

INSERT INTO Modules (ModuleID, CourseID, Title, difficulty, contentURL)
VALUES
    (1,1, 'Module 1', 'Easy', 'http://example.com/module1'),
    (2,2, 'Module 2', 'Easy', 'http://example.com/module2'),
    (3,3, 'Module 3', 'Easy', 'http://example.com/module3'),
    (4,4, 'Module 4', 'Medium', 'http://example.com/module4'),
    (5,5, 'Module 5', 'Medium', 'http://example.com/module5'),
    (6,6, 'Module 6', 'Medium', 'http://example.com/module6'),
    (7,7, 'Module 7', 'Hard', 'http://example.com/module7'),
    (8,8, 'Module 8', 'Hard', 'http://example.com/module8'),
    (9,9, 'Module 9', 'Hard', 'http://example.com/module9'),
    (10,10, 'Module 10', 'Very Hard', 'http://example.com/module10');


INSERT INTO Target_traits (ModuleID, CourseID, Trait)
VALUES
    (1, 1, 'Skill'),
    (2, 2, 'Creative'),
    (3, 3, 'Logical'),
    (4, 4, 'Critical Thinking'),
    (5, 5, 'Problem Solving'),
    (6, 6, 'Teamwork'),
    (7, 7, 'Leadership'),
    (8, 8, 'Communication'),
    (9, 9, 'Adaptability'),
    (10, 10, 'Time Management');

INSERT INTO ModuleContent (ModuleID, CourseID, content_type)
VALUES
    (1, 1, 'Video'),
    (2, 2, 'Text'),
    (3, 3, 'Audio'),
    (4, 4, 'Interactive'),
    (5, 5, 'Video'),
    (6, 6, 'Text'),
    (7, 7, 'Audio'),
    (8, 8, 'Interactive'),
    (9, 9, 'Video'),
    (10, 10, 'Text');

INSERT INTO ContentLibrary (ID, ModuleID, CourseID, Title, library_description, metadata, library_type, content_URL)
VALUES
    (1,1, 1, 'Intro to Math', 'Basic math concepts', 'Math', 'Video', 'http://example.com/intro_math'),
    (2,2, 2, 'Intro to Science', 'Basic science concepts', 'Science', 'Text', 'http://example.com/intro_science'),
    (3,3, 3, 'Intro to History', 'Basic history concepts', 'History', 'Audio', 'http://example.com/intro_history'),
    (4,4, 4, 'Intermediate Math', 'Intermediate math concepts', 'Math', 'Interactive', 'http://example.com/intermediate_math'),
    (5,5, 5, 'Intermediate Science', 'Intermediate science concepts', 'Science', 'Video', 'http://example.com/intermediate_science'),
    (6,6, 6, 'Intermediate History', 'Intermediate history concepts', 'History', 'Text', 'http://example.com/intermediate_history'),
    (7,7, 7, 'Advanced Math', 'Advanced math concepts', 'Math', 'Audio', 'http://example.com/advanced_math'),
    (8,8, 8, 'Advanced Science', 'Advanced science concepts', 'Science', 'Interactive', 'http://example.com/advanced_science'),
    (9,9, 9, 'Advanced History', 'Advanced history concepts', 'History', 'Video', 'http://example.com/advanced_history'),
    (10,10, 10, 'Expert Math', 'Expert level math concepts', 'Math', 'Text', 'http://example.com/expert_math');

INSERT INTO Assessments (ID, ModuleID, CourseID, assessment_type, total_marks, passing_marks, criteria, weightage, assessment_description, title)
VALUES
    (1, 1, 1, 'Quiz', 100, 50, 'Basic Math', 10, 'Basic math quiz', 'Math Quiz 1'),
    (2, 2, 2, 'Quiz', 100, 50, 'Basic Science', 10, 'Basic science quiz', 'Science Quiz 1'),
    (3, 3, 3, 'Quiz', 100, 50, 'Basic History', 10, 'Basic history quiz', 'History Quiz 1'),
    (4, 4, 4, 'Exam', 200, 100, 'Intermediate Math', 20, 'Intermediate math exam', 'Math Exam 1'),
    (5, 5, 5, 'Exam', 200, 100, 'Intermediate Science', 20, 'Intermediate science exam', 'Science Exam 1'),
    (6, 6, 6, 'Exam', 200, 100, 'Intermediate History', 20, 'Intermediate history exam', 'History Exam 1'),
    (7, 7, 7, 'Project', 300, 150, 'Advanced Math', 30, 'Advanced math project', 'Math Project 1'),
    (8, 8, 8, 'Project', 300, 150, 'Advanced Science', 30, 'Advanced science project', 'Science Project 1'),
    (9, 9, 9, 'Project', 300, 150, 'Advanced History', 30, 'Advanced history project', 'History Project 1'),
    (10, 10, 10, 'Final Exam', 400, 200, 'Expert Math', 40, 'Expert level math final exam', 'Math Final Exam');

INSERT INTO Takenassessment (AssessmentID, LearnerID, scoredPoint)
VALUES
    (1, 1, 85),
    (2, 2, 90),
    (3, 3, 75),
    (4, 4, 80),
    (5, 5, 95),
    (6, 6, 70),
    (7, 7, 85),
    (8, 8, 90),
    (9, 9, 75),
    (10, 10, 80);

INSERT INTO Learning_activities ( ModuleID, CourseID, activity_type, instruction_details, Max_points)
VALUES
    ( 1, 1, 'Quiz', 'Complete the quiz on basic math concepts', 10),
    ( 2, 2, 'Assignment', 'Submit the assignment on basic science concepts', 20),
    ( 3, 3, 'Project', 'Work on the project about basic history', 30),
    ( 4, 4, 'Quiz', 'Complete the quiz on intermediate math concepts', 15),
    ( 5, 5, 'Assignment', 'Submit the assignment on intermediate science concepts', 25),
    ( 6, 6, 'Project', 'Work on the project about intermediate history', 35),
    ( 7, 7, 'Quiz', 'Complete the quiz on advanced math concepts', 20),
    (8, 8, 'Assignment', 'Submit the assignment on advanced science concepts', 30),
    ( 9, 9, 'Project', 'Work on the project about advanced history', 40),
    ( 10, 10, 'Quiz', 'Complete the quiz on expert math concepts', 25);

INSERT INTO Interaction_log (logID, activity_ID, LearnerID, Duration, interaction_Timestamp, action_type)
VALUES
    (1, 1, 1, 30, '2023-10-01 10:00:00', 'Completed'),
    (2, 2, 2, 45, '2023-10-02 11:00:00', 'Submitted'),
    (3, 3, 3, 60, '2023-10-03 12:00:00', 'Started'),
    (4, 4, 4, 35, '2023-10-04 13:00:00', 'Completed'),
    (5,5, 5, 50, '2023-10-05 14:00:00', 'Submitted'),
    (6,6,  6, 70, '2023-10-06 15:00:00', 'Started'),
    (7, 7, 7,40, '2023-10-07 16:00:00', 'Completed'),
    (8, 8,8,  55, '2023-10-08 17:00:00', 'Submitted'),
    (9, 9,9,  80, '2023-10-09 18:00:00', 'Started'),
    (10, 10,10, 45, '2023-10-10 19:00:00', 'Completed');

INSERT INTO Emotional_feedback ( LearnerID, activityID, feedback_timestamp, emotional_state)
VALUES
    ( 1, 1, '2023-10-01 10:30:00', 'Happy'),
    ( 2, 2, '2023-10-02 11:45:00', 'Neutral'),
    ( 3, 3, '2023-10-03 12:30:00', 'Sad'),
    ( 4, 4, '2023-10-04 13:35:00', 'Happy'),
    ( 5, 5, '2023-10-05 14:50:00', 'Neutral'),
    ( 6, 6, '2023-10-06 15:30:00', 'Sad'),
    ( 7, 7, '2023-10-07 16:40:00', 'Happy'),
    ( 8, 8, '2023-10-08 17:55:00', 'Neutral'),
    ( 9, 9, '2023-10-09 18:30:00', 'Sad'),
    ( 10, 10, '2023-10-10 19:45:00', 'Happy');

INSERT INTO Learning_path ( LearnerID, ProfileID, completion_status, custom_content, adaptive_rules)
VALUES
    ( 1, 1, 'In Progress', 'Custom content for learner 1', 'Adaptive rule 1'),
    ( 2, 2, 'Completed', 'Custom content for learner 2', 'Adaptive rule 2'),
    ( 3, 3, 'In Progress', 'Custom content for learner 3', 'Adaptive rule 3'),
    ( 4, 4, 'Completed', 'Custom content for learner 4', 'Adaptive rule 4'),
    ( 5, 5, 'In Progress', 'Custom content for learner 5', 'Adaptive rule 5'),
    ( 6, 6, 'Completed', 'Custom content for learner 6', 'Adaptive rule 6'),
    ( 7, 7, 'In Progress', 'Custom content for learner 7', 'Adaptive rule 7'),
    ( 8, 8, 'Completed', 'Custom content for learner 8', 'Adaptive rule 8'),
    ( 9, 9, 'In Progress', 'Custom content for learner 9', 'Adaptive rule 9'),
    ( 10, 10, 'Completed', 'Custom content for learner 10', 'Adaptive rule 10');

INSERT INTO Instructor (InstructorID, instructor_name, latest_qualification, expertise_area, email)
VALUES
    (1, 'Dr. John Smith', 'PhD in Mathematics', 'Mathematics', 'john.smith@example.com'),
    (2, 'Dr. Jane Doe', 'PhD in Science', 'Science', 'jane.doe@example.com'),
    (3, 'Dr. Alice Johnson', 'PhD in History', 'History', 'alice.johnson@example.com'),
    (4, 'Dr. Bob Brown', 'PhD in Computer Science', 'Computer Science', 'bob.brown@example.com'),
    (5, 'Dr. Charlie Davis', 'PhD in Physics', 'Physics', 'charlie.davis@example.com'),
    (6, 'Dr. Diana Evans', 'PhD in Chemistry', 'Chemistry', 'diana.evans@example.com'),
    (7, 'Dr. Eve Wilson', 'PhD in Biology', 'Biology', 'eve.wilson@example.com'),
    (8, 'Dr. Frank Garcia', 'PhD in Engineering', 'Engineering', 'frank.garcia@example.com'),
    (9, 'Dr. Grace Martinez', 'PhD in Economics', 'Economics', 'grace.martinez@example.com'),
    (10,'Dr. Hank Lee', 'PhD in Literature', 'Literature', 'hank.lee@example.com');

INSERT INTO Pathreview (InstructorID, PathID, review)
VALUES
    (1, 1, 'Great progress'),
    (2, 2, 'Needs improvement'),
    (3, 3, 'Excellent work'),
    (4, 4, 'Keep it up'),
    (5, 5, 'Good effort'),
    (6, 6, 'Satisfactory'),
    (7, 7, 'Outstanding'),
    (8, 8, 'Well done'),
    (9, 9, 'Average performance'),
    (10, 10, 'Below expectations');

INSERT INTO Emotionalfeedback_review (FeedbackID, InstructorID, review)
VALUES
    (1, 1, 'Positive feedback'),
    (2, 2, 'Neutral feedback'),
    (3, 3, 'Negative feedback'),
    (4, 4, 'Positive feedback'),
    (5, 5, 'Neutral feedback'),
    (6, 6, 'Negative feedback'),
    (7, 7, 'Positive feedback'),
    (8, 8, 'Neutral feedback'),
    (9, 9, 'Negative feedback'),
    (10, 10, 'Positive feedback');

INSERT INTO Course_enrollment ( CourseID, LearnerID, completion_date, enrollment_date, enrollment_status)
VALUES
    ( 1, 1, '2023-12-01', '2023-01-01', 'Completed'),
    ( 2, 2, '2023-12-02', '2023-02-01', 'Completed'),
    (3, 3, '2023-12-03', '2023-03-01', 'Completed'),
    ( 4, 4, '2023-12-04', '2023-04-01', 'Completed'),
    ( 5, 5, '2023-12-05', '2023-05-01', 'Completed'),
    ( 6, 6, '2023-12-06', '2023-06-01', 'Completed'),
    ( 7, 7, '2023-12-07', '2023-07-01', 'Completed'),
    ( 8, 8, '2023-12-08', '2023-08-01', 'Completed'),
    ( 9, 9, '2023-12-09', '2023-09-01', 'Completed'),
    ( 10, 10, '2023-12-10', '2023-10-01', 'Completed');
SELECT * FROM Course;
INSERT INTO Teaches (InstructorID, CourseID)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10);

INSERT INTO Leaderboard (BoardID, season)
VALUES
    (1, 'Spring 2023'),
    (2 ,'Summer 2023'),
    (3, 'Fall 2023'),
    (4, 'Winter 2023'),
    (5, 'Spring 2024'),
    (6, 'Summer 2024'),
    (7, 'Fall 2024'),
    (8, 'Winter 2024'),
    (9, 'Spring 2025'),
    (10, 'Summer 2025');

INSERT INTO Ranking (BoardID, LearnerID, CourseID, rankNum, total_points)
VALUES
    (1, 1, 1, 1, 100),
    (2, 2, 2, 2, 90),
    (3, 3, 3, 3, 80),
    (4, 4, 4, 4, 70),
    (5, 5, 5, 5, 60),
    (6, 6, 6, 6, 50),
    (7, 7, 7, 7, 40),
    (8, 8, 8, 8, 30),
    (9, 9, 9, 9, 20),
    (10, 10, 10, 10, 10);

INSERT INTO Learning_goal (ID, goal_status, deadline, goal_description)
VALUES
    (1, 'In Progress', '2023-12-31', 'Complete the course'),
    (2, 'Completed', '2023-11-30', 'Submit the project'),
    (3, 'In Progress', '2023-10-31', 'Pass the exam'),
    (4, 'Completed', '2023-09-30', 'Finish the assignment'),
    (5, 'In Progress', '2023-08-31', 'Attend all lectures'),
    (6, 'Completed', '2023-07-31', 'Participate in the discussion'),
    (7, 'In Progress', '2023-06-30', 'Complete the quiz'),
    (8, 'Completed', '2023-05-31', 'Submit the report'),
    (9, 'In Progress', '2023-04-30', 'Finish the lab work'),
    (10, 'Completed', '2023-03-31', 'Attend the workshop');

INSERT INTO LearnersGoals (GoalID, LearnerID)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10);

INSERT INTO Survey (ID, Title)
VALUES
    (1, 'Course Feedback'),
    (2, 'Instructor Evaluation'),
    (3, 'Module Satisfaction'),
    (4, 'Learning Experience'),
    (5, 'Assessment Review'),
    (6, 'Content Quality'),
    (7, 'Platform Usability'),
    (8, 'Support Services'),
    (9, 'Overall Satisfaction'),
    (10, 'Future Courses');

INSERT INTO SurveyQuestions (SurveyID, Question)
VALUES
    (1, 'How would you rate the course content?'),
    (2, 'How would you rate the instructor?'),
    (3, 'How satisfied are you with the module?'),
    (4, 'How was your overall learning experience?'),
    (5, 'How would you rate the assessments?'),
    (6, 'How would you rate the quality of the content?'),
    (7, 'How user-friendly is the platform?'),
    (8, 'How would you rate the support services?'),
    (9, 'How satisfied are you overall?'),
    (10, 'What courses would you like to see in the future?');

INSERT INTO FilledSurvey (SurveyID, LearnerID, Answer)
VALUES
    (1, 1, 'Excellent'),
    (2, 2, 'Good'),
    (3, 3, 'Average'),
    (4, 4, 'Poor'),
    (5, 5, 'Excellent'),
    (6, 6, 'Good'),
    (7, 7, 'Average'),
    (8, 8, 'Poor'),
    (9, 9, 'Excellent'),
    (10, 10, 'Good');

INSERT INTO SystemNotification (ID ,notification_timestamp, notification_message, urgency_level, ReadStatus)
VALUES
    (1, '2023-10-01 10:00:00', 'New course available', 'High', 0),
    (2,'2023-10-02 11:00:00', 'Assignment due soon', 'Medium', 0),
    (3, '2023-10-03 12:00:00', 'Quiz results released', 'Low', 0),
    (4, '2023-10-04 13:00:00', 'New discussion forum post', 'High', 0),
    (5, '2023-10-05 14:00:00', 'Course enrollment open', 'Medium', 0),
    (6, '2023-10-06 15:00:00', 'Project submission deadline', 'High', 0),
    (7, '2023-10-07 16:00:00', 'New module added', 'Low', 0),
    (8, '2023-10-08 17:00:00', 'Feedback requested', 'Medium', 0),
    (9,'2023-10-09 18:00:00', 'System maintenance scheduled', 'High', 0),
    (10, '2023-10-10 19:00:00', 'New badge earned', 'Low', 0);

INSERT INTO ReceivedNotification (NotificationID, LearnerID)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10);

INSERT INTO Badge (BadgeID, title, badge_description, criteria, points)
VALUES
    (1, 'Math Whiz', 'Awarded for excellence in math', 'Complete all math courses', 100),
    (2, 'Science Star', 'Awarded for excellence in science', 'Complete all science courses', 100),
    (3, 'History Buff', 'Awarded for excellence in history', 'Complete all history courses', 100),
    (4, 'Programming Pro', 'Awarded for excellence in programming', 'Complete all programming courses', 100),
    (5, 'Quiz Master', 'Awarded for high quiz scores', 'Score above 90% in quizzes', 50),
    (6, 'Project Leader', 'Awarded for leading projects', 'Lead a project team', 50),
    (7, 'Discussion Contributor', 'Awarded for active participation in discussions', 'Post 10 times in forums', 30),
    (8, 'Assignment Ace', 'Awarded for excellent assignments', 'Score above 90% in assignments', 50),
    (9, 'Course Completer', 'Awarded for completing courses', 'Complete 5 courses', 70),
    (10, 'Feedback Giver', 'Awarded for providing feedback', 'Submit feedback for 5 courses', 20);

INSERT INTO SkillProgression (ID, proficiency_level, LearnerID, skill_name, skillProgression_timestamp)
VALUES
    (1, 'Beginner', 1, 'Python', '2023-10-01 10:00:00'),
    (2, 'Intermediate', 2, 'Java', '2023-10-02 11:00:00'),
    (3, 'Advanced', 3, 'SQL', '2023-10-03 12:00:00'),
    (4, 'Expert', 4, 'JavaScript', '2023-10-04 13:00:00'),
    (5, 'Beginner', 5, 'C++', '2023-10-05 14:00:00'),
    (6, 'Intermediate', 6, 'HTML', '2023-10-06 15:00:00'),
    (7, 'Advanced', 7, 'CSS', '2023-10-07 16:00:00'),
    (8, 'Expert', 8, 'Ruby', '2023-10-08 17:00:00'),
    (9, 'Beginner', 9, 'PHP', '2023-10-09 18:00:00'),
    (10, 'Intermediate', 10, 'Swift', '2023-10-10 19:00:00');

INSERT INTO Reward (RewardID, reward_value, reward_description, reward_type)
VALUES
    (1, 100, 'Gift Card', 'Monetary'),
    (2, 50, 'Discount Coupon', 'Monetary'),
    (3, 200, 'Free Course', 'Non-Monetary'),
    (4, 150, 'Extra Credit', 'Academic'),
    (5, 75, 'Certificate', 'Academic'),
    (6, 120, 'Book', 'Non-Monetary'),
    (7, 90, 'Workshop Access', 'Non-Monetary'),
    (8, 110, 'Software License', 'Non-Monetary'),
    (9, 80, 'Online Subscription', 'Non-Monetary'),
    (10, 60, 'Merchandise', 'Non-Monetary');



INSERT INTO Quest ( difficulty_level, criteria, quest_description, title)
VALUES
    ( 'Easy', 'Complete Module 1', 'Introduction to the course', 'Intro Quest'),
    ( 'Medium', 'Score 80% in Quiz', 'Intermediate level challenge', 'Quiz Master'),
    ( 'Hard', 'Finish Project', 'Advanced project work', 'Project Pro'),
    ( 'Very Hard', 'Complete All Modules', 'Expert level challenge', 'Expert Quest'),
    ( 'Easy', 'Attend Workshop', 'Basic workshop participation', 'Workshop Attendee'),
    ( 'Medium', 'Submit Assignment', 'Intermediate assignment submission', 'Assignment Ace'),
    ( 'Hard', 'Lead Team', 'Advanced team leadership', 'Team Leader'),
    ( 'Very Hard', 'Publish Paper', 'Expert level research', 'Researcher'),
    ( 'Easy', 'Participate in Discussion', 'Basic forum participation', 'Forum Contributor'),
    ( 'Medium', 'Complete Survey', 'Intermediate feedback submission', 'Survey Taker');


INSERT INTO Skill_Mastery (QuestID, skill)
VALUES
    (1, 'Python'),
    (2, 'Java'),
    (3, 'SQL'),
    (4, 'JavaScript'),
    (5, 'C++'),
    (6, 'HTML'),
    (7, 'CSS'),
    (8, 'Ruby'),
    (9, 'PHP'),
    (10, 'Swift');

INSERT INTO Collaborative (QuestID, deadline, max_num_participants)
VALUES
    (1, '2023-12-31', 5),
    (2, '2023-11-30', 10),
    (3, '2023-10-31', 8),
    (4, '2023-09-30', 6),
    (5, '2023-08-31', 12),
    (6, '2023-07-31', 7),
    (7, '2023-06-30', 9),
    (8, '2023-05-31', 4),
    (9, '2023-04-30', 11),
    (10, '2023-03-31', 3);

INSERT INTO LearnersCollaboration (LearnerID, QuestID, completion_status)
VALUES
    (1, 1, 'In Progress'),
    (2, 2, 'Completed'),
    (3, 3, 'In Progress'),
    (4, 4, 'Completed'),
    (5, 5, 'In Progress'),
    (6, 6, 'Completed'),
    (7, 7, 'In Progress'),
    (8, 8, 'Completed'),
    (9, 9, 'In Progress'),
    (10, 10, 'Completed');

INSERT INTO QuestReward (RewardID, QuestID, LearnerID, Time_earned)
VALUES
    (1, 1, 1, '2023-10-01 10:00:00'),
    (2, 2, 2, '2023-10-02 11:00:00'),
    (3, 3, 3, '2023-10-03 12:00:00'),
    (4, 4, 4, '2023-10-04 13:00:00'),
    (5, 5, 5, '2023-10-05 14:00:00'),
    (6, 6, 6, '2023-10-06 15:00:00'),
    (7, 7, 7, '2023-10-07 16:00:00'),
    (8, 8, 8, '2023-10-08 17:00:00'),
    (9, 9, 9, '2023-10-09 18:00:00'),
    (10, 10, 10, '2023-10-10 19:00:00');


INSERT INTO Discussion_forum (ModuleID, CourseID, title, last_active, forum_timestamp, forum_description)
VALUES
    ( 1, 1, 'Math Discussion', '10:00:00', '2023-10-01 10:00:00', 'Discuss Math 101 topics'),
    ( 2, 2, 'Science Discussion', '11:00:00', '2023-10-02 11:00:00', 'Discuss Science 101 topics'),
    ( 3, 3, 'History Discussion', '12:00:00', '2023-10-03 12:00:00', 'Discuss History 101 topics'),
    ( 4, 4, 'Intermediate Math Discussion', '13:00:00', '2023-10-04 13:00:00', 'Discuss Math 102 topics'),
    ( 5, 5, 'Intermediate Science Discussion', '14:00:00', '2023-10-05 14:00:00', 'Discuss Science 102 topics'),
    ( 6, 6, 'Intermediate History Discussion', '15:00:00', '2023-10-06 15:00:00', 'Discuss History 102 topics'),
    ( 7, 7, 'Advanced Math Discussion', '16:00:00', '2023-10-07 16:00:00', 'Discuss Math 103 topics'),
    ( 8, 8, 'Advanced Science Discussion', '17:00:00', '2023-10-08 17:00:00', 'Discuss Science 103 topics'),
    ( 9, 9, 'Advanced History Discussion', '18:00:00', '2023-10-09 18:00:00', 'Discuss History 103 topics'),
    ( 10, 10, 'Expert Math Discussion', '19:00:00', '2023-10-10 19:00:00', 'Discuss Math 104 topics');


INSERT INTO LearnerDiscussion (ForumID, LearnerID, Post, discussion_time)
VALUES
    (1, 1, 'This is a great module!', '2023-10-01 10:00:00'),
    (2, 2, 'I found this topic challenging.', '2023-10-02 11:00:00'),
    (3, 3, 'Can someone help with this question?', '2023-10-03 12:00:00'),
    (4, 4, 'I enjoyed this lesson.', '2023-10-04 13:00:00'),
    (5, 5, 'This assignment was tough.', '2023-10-05 14:00:00'),
    (6, 6, 'Great resources provided.', '2023-10-06 15:00:00'),
    (7, 7, 'I need help with the project.', '2023-10-07 16:00:00'),
    (8, 8, 'This quiz was easy.', '2023-10-08 17:00:00'),
    (9, 9, 'I learned a lot from this module.', '2023-10-09 18:00:00'),
    (10, 10, 'Looking forward to the next lesson.', '2023-10-10 19:00:00');


INSERT INTO Achievement ( LearnerID, BadgeID, achievement_description, date_earned, achievement_type)
VALUES
    ( 1, 1, 'Completed Math 101', '2023-12-01', 'Course Completion'),
    ( 2, 2, 'Completed Science 101', '2023-12-02', 'Course Completion'),
    ( 3, 3, 'Completed History 101', '2023-12-03', 'Course Completion'),
    ( 4, 4, 'Completed Math 102', '2023-12-04', 'Course Completion'),
    ( 5, 5, 'Completed Science 102', '2023-12-05', 'Course Completion'),
    ( 6, 6, 'Completed History 102', '2023-12-06', 'Course Completion'),
    ( 7, 7, 'Completed Math 103', '2023-12-07', 'Course Completion'),
    ( 8, 8, 'Completed Science 103', '2023-12-08', 'Course Completion'),
    ( 9, 9, 'Completed History 103', '2023-12-09', 'Course Completion'),
    ( 10, 10, 'Completed Math 104', '2023-12-10', 'Course Completion');

INSERT INTO LearnersMastery (LearnerID, QuestID, skill, completion_status)
VALUES
    (1, 1, 'Python', 'Completed'),
    (2, 2, 'Java', 'In Progress'),
    (3, 3, 'SQL', 'Completed'),
    (4, 4, 'JavaScript', 'In Progress'),
    (5, 5, 'C++', 'Completed'),
    (6, 6, 'HTML', 'In Progress'),
    (7, 7, 'CSS', 'Completed'),
    (8, 8, 'Ruby', 'In Progress'),
    (9, 9, 'PHP', 'Completed'),
    (10, 10, 'Swift', 'In Progress');




INSERT INTO Interaction_log (logID, activity_ID, LearnerID, Duration, interaction_Timestamp, action_type)
VALUES (100, 2, 1, 30, '2023-10-01 10:00:00', 'Completed');

SELECT * FROM Learning_activities;

INSERT INTO Target_traits (ModuleID, CourseID, Trait)
VALUES (2, 2, 'Skill');

INSERT INTO LearnersMastery (LearnerID, QuestID, skill, completion_status)
VALUES (3, 2, 'Python', 'Completed');

