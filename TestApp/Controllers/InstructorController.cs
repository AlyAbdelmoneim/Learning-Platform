using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TestApp.Context;
using TestApp.Models;
using TestApp.Models.ViewModels;
// using TestApp.Views.Learner;

namespace TestApp.Controllers
{
    public class InstructorController : Controller
    {
        private readonly MyDbContext _context;

        public InstructorController(MyDbContext context)
        {
            _context = context;
        }

        // Instructor Dashboard
        [HttpGet]
        public IActionResult InstructorDashboard()
        {
            int? instructorId = HttpContext.Session.GetInt32("UserID");

            if (instructorId.HasValue)
            {
                var instructor = _context.Instructors.FirstOrDefault(i => i.InstructorID == instructorId.Value);
                if (instructor != null)
                {
                    return View(instructor); // Pass the instructor model to the view
                }
                else
                {
                    TempData["ErrorMessage"] = "Instructor not found.";
                    return RedirectToAction("Login", "Account");
                }
            }

            TempData["ErrorMessage"] = "You must be logged in to access the instructor dashboard.";
            return RedirectToAction("Login", "Account"); // Redirect to login page if no session
        }

        [HttpGet]
        public IActionResult EditInstructorProfile()
        {
            var instructorId = HttpContext.Session.GetInt32("UserID");

            if (instructorId.HasValue)
            {
                var instructor = _context.Instructors.FirstOrDefault(i => i.InstructorID == instructorId);
                if (instructor != null)
                {
                    return View(instructor); // Pass the instructor model to the view
                }
            }

            TempData["ErrorMessage"] = "Instructor not found.";
            return RedirectToAction("InstructorDashboard");
        }

        [HttpPost]
        public IActionResult EditInstructorProfile(Instructor updatedInstructor)
        {
            var instructorId = HttpContext.Session.GetInt32("UserID");

            if (ModelState.IsValid && instructorId.HasValue)
            {
                var instructor = _context.Instructors.FirstOrDefault(i => i.InstructorID == instructorId);
                if (instructor != null)
                {
                    instructor.instructor_name = updatedInstructor.instructor_name;
                    instructor.latest_qualification = updatedInstructor.latest_qualification;
                    instructor.expertise_area = updatedInstructor.expertise_area;
                    instructor.email = updatedInstructor.email;

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Profile updated successfully.";
                    return RedirectToAction("InstructorDashboard");
                }
            }

            TempData["ErrorMessage"] = "Invalid profile data for instructor. Please check your inputs.";
            return View(updatedInstructor);
        }


        [HttpPost]
        public IActionResult DeleteInstructorAccount(int instructorId)
        {
            var instructor = _context.Instructors.FirstOrDefault(i => i.InstructorID == instructorId);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Your account has been successfully deleted.";
                return RedirectToAction("Login", "Account");
            }

            TempData["ErrorMessage"] = "Instructor not found.";
            return RedirectToAction("InstructorDashboard", new { instructorId = instructorId });
        }

        [HttpGet]
        public IActionResult LearnersPage()
        {
            var learners = _context.Learners.Where(l => l.email != null).ToList();
            return View(learners);
        }

        public IActionResult LearnersPastCourses(int learnerId)
        {
            var pastCourses = _context.Courses.FromSqlRaw("EXEC CompletedCourses @LearnerID = {0}", learnerId).ToList();
            return View(pastCourses);
        }

        [HttpGet]
        public IActionResult PersonalizationProfile(int learnerId)
        {
            var personalizationProfiles = _context.PersonalizationProfiles
                .Where(p => p.LearnerID == learnerId)
                .ToList();
            return View(personalizationProfiles);
        }

        public IActionResult AddPathToLearner(int learnerId, int profileId)
        {
            // Debugging: Ensure these values are received correctly in the controller
            Console.WriteLine("learnerId: " + learnerId + " profileId: " + profileId);

            // Pass these values to the view using ViewData or directly into the view
            ViewData["LearnerId"] = learnerId;
            ViewData["ProfileId"] = profileId;

            return View();
        }

        [HttpPost]
        public IActionResult AddPathToLearner(int LearnerId, int ProfileId, string CustomContent, string AdaptiveRules)
        {
            try
            {
                // Execute the stored procedure or logic to add a path to the learner
                _context.Database.ExecuteSqlRaw(
                    "EXEC NewPath @LearnerID = {0}, @ProfileID = {1}, @completion_status = {2}, @custom_content = {3}, @adaptiverules = {4}",
                    LearnerId, ProfileId, "New", CustomContent, AdaptiveRules);

                TempData["SuccessMessage"] = "Path successfully added to learner!";
                return RedirectToAction("LearnersPage", "Instructor");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] =
                    $"Error adding path: {ex.Message} \n\n learnerId: {LearnerId}, profileId: {ProfileId}, customContent: {CustomContent}, adaptiveRules: {AdaptiveRules}";
                return View();
            }
        }

        public IActionResult Courses()
        {
            var courses = _context.Courses
                .FromSqlRaw("EXEC InstructorCourses {0}", HttpContext.Session.GetInt32("UserID")).ToList();
            return View(courses);
        }

        public IActionResult Modules(int courseID)
        {
            Console.WriteLine("Course ID: " + courseID);
            var modules = _context.Modules.FromSqlRaw("Exec dbo.GetModulesForCourse @CourseID = {0}", courseID)
                .ToList();
            return View(modules);
        }

        public IActionResult DiscussionForums(int courseID, int moduleID)
        {
            var forums = _context.Discussion_forums
                .FromSqlRaw("Exec dbo.GetDiscussionForums @CourseID = {0}, @ModuleID = {1}", courseID, moduleID)
                .ToList();
            IntDTO course = new IntDTO { Value = courseID };
            IntDTO module = new IntDTO { Value = moduleID };
            var tuple = new Tuple<List<Discussion_forum>, IntDTO, IntDTO>(forums, course, module);
            return View(tuple);
        }

        public IActionResult Posts(int forumID)
        {
            var posts = _context.LearnerDiscussions.FromSqlRaw("Exec dbo.GetPostsForForum @ForumID = {0}", forumID)
                .ToList();
            var tuple = new Tuple<List<LearnerDiscussion>, int>(posts, forumID);
            return View(tuple);
        }

        public IActionResult AddDiscussionForum(int courseID, int moduleID)
        {
            ViewData["CourseID"] = courseID;
            ViewData["ModuleID"] = moduleID;
            return View();
        }

        [HttpPost]
        public IActionResult AddDiscussionForum(Discussion_forum forum)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "Exec dbo.CreateDiscussion @ModuleID = {0}, @CourseID = {1}, @title = {2}, @description = {3}",
                    forum.ModuleID, forum.CourseID, forum.title, forum.forum_description);
                TempData["SuccessMessage"] = "Discussion forum added successfully!";
                return RedirectToAction("DiscussionForums",
                    new { courseID = forum.CourseID, moduleID = forum.ModuleID });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error adding discussion forum: " + ex.Message;
                return View();
            }
        }

        public IActionResult Quests()
        {
            return View();
        }

        public IActionResult SkillMasteryQuests()
        {
            var skillMasteryQuests =
                _context.SkillMasteryViewModels.FromSqlRaw("EXEC GetAllSkillMasteryQuests").ToList();
            return View(skillMasteryQuests);
        }

        public IActionResult CollaborativeQuests()
        {
            var collaborativeQuests = _context.CollaborativeQuestsViewModels
                .FromSqlRaw("EXEC GetAllCollaborativeQuests").ToList();
            return View(collaborativeQuests);
        }

        public IActionResult UpdateDeadline1(int questsID)
        {
            Console.WriteLine("Coming Quest ID: " + questsID);
            return View(new UpdatedDeadlineViewModel { questsID = questsID });
        }

        public IActionResult UpdateDeadline(UpdatedDeadlineViewModel model)
        {
            Console.WriteLine("Quest ID: " + model.questsID + " Deadline: " + model.deadline);
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC DeadlineUpdate @QuestID = {0}, @deadline = {1}",
                    model.questsID, model.deadline);
                TempData["SuccessMessage"] = "Deadline updated successfully!";
                return RedirectToAction("CollaborativeQuests");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error updating deadline: " + ex.Message;
                return RedirectToAction("CollaborativeQuests");
            }
        }

        public IActionResult AddSkillMasteryQuest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkillMasteryQuest(SkillMasteryViewModel quest)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC SkillMasteryQuest @difficulty_level = {0}, @criteria = {1}, @quest_description = {2}, @title = {3}, @skill = {4}",
                    quest.difficulty_level, quest.criteria, quest.quest_description, quest.title, quest.skill);
                TempData["SuccessMessage"] = "Skill mastery quest added successfully!";
                return RedirectToAction("SkillMasteryQuests");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error adding skill mastery quest: " + ex.Message;
                return View();
            }
        }

        public IActionResult AddCollaborativeQuest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCollaborativeQuest(CollaborativeQuestsViewModel quest)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC CollaborativeQuest @difficulty_level = {0}, @criteria = {1}, @quest_description = {2}, @title = {3}, @Maxnumparticipants = {4}, @deadline = {5}",
                    quest.difficulty_level, quest.criteria, quest.quest_description, quest.title,
                    quest.max_num_participants, quest.deadline);
                TempData["SuccessMessage"] = "Skill mastery quest added successfully!";
                return RedirectToAction("CollaborativeQuests");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error adding skill mastery quest: " + ex.Message;
                return View();
            }
        }

        public IActionResult DeleteQuests1()
        {
            return View();
        }

        public IActionResult DeleteQuests(String criteria)
        {
            Console.WriteLine("coming Criteria: " + criteria);
            _context.Database.ExecuteSqlRaw("EXEC CirteriaDelete @criteria = {0}", criteria);
            TempData["SuccessMessage"] = "Quest deleted successfully!";
            return RedirectToAction("Quests");
        }

        public IActionResult Achievements()
        {
            var achievements = _context.Achievements.FromSqlRaw("EXEC GetAllAchievements").ToList();
            return View(achievements);
        }

        public IActionResult AddAchievement1()
        {
            return View();
        }

        public IActionResult AddAchievement(int learnerID, int badgeID, String description, DateTime dateEarned,
            String type)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC NewAchievement @LearnerID = {0}, @BadgeID = {1}, @description = {2}, @date_earned = {3}, @type = {4}",
                    learnerID, badgeID, description, dateEarned, type);
                TempData["SuccessMessage"] = "Achievement added successfully!";
                SendNotification(learnerID, "New Achievement", "High");
                return RedirectToAction("Achievements");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error adding achievement: " + ex.Message;
                return View();
            }
        }

        public void SendNotification(int learnerID, string message, string urgencyLeve)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC SendNotification @LearnerID = {0}, @message = {1}, @urgencyLevel = {2}",
                learnerID, message, urgencyLeve);
        }

        public IActionResult AddModule1(int courseID)
        {
            IntDTO course = new IntDTO { Value = courseID };
            return View(course);
        }

        public IActionResult AddModule(int courseID, string title, string difficulty, string contentURL, string trait,
            string contentType)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC AddNewModule @CourseID = {0}, @Title = {1}, @Difficulty = {2}, @ContentURL = {3}, @Trait = {4}, @ContentType = {5}",
                    courseID, title, difficulty, contentURL, trait, contentType);
                TempData["SuccessMessage"] = "Module added successfully!";
                return RedirectToAction("Modules", new { courseID = courseID });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding module: " + ex.Message);
                return View("AddModule1", new IntDTO { Value = courseID });
            }
        }

        public IActionResult Leaderboard(int leaderboardId)
        {
            Console.WriteLine("Leaderboard Id is " + leaderboardId);
            var leaderboard = _context.RankingViewModels
                .FromSqlRaw("EXEC dbo.LeaderboardRank @LeaderboardID = {0}", leaderboardId).ToList();
            return View(leaderboard);
        }

        public IActionResult Activities(int courseId, int moduleId)
        {
            var activities = _context.Learning_activities
                .FromSqlRaw("EXEC dbo.GetActivities @CourseID = {0}, @ModuleID = {1}", courseId, moduleId).ToList();
            IntDTO course = new IntDTO { Value = courseId };
            IntDTO module = new IntDTO { Value = moduleId };
            var tuple = new Tuple<List<Learning_activity>, IntDTO, IntDTO>(activities, course, module);
            return View(tuple);
        }

        public IActionResult AddLearningActivity1(int courseId, int moduleId)
        {
            IntDTO course = new IntDTO { Value = courseId };
            IntDTO module = new IntDTO { Value = moduleId };
            var tuple = new Tuple<IntDTO, IntDTO>(course, module);
            return View(tuple);
        }

        public IActionResult AddLearningActivity(int moduleId, int courseId, string type, string instructionDetails,
            int maxScore)
        {
            Console.WriteLine("Coming values are " + moduleId + " " + courseId + " " + type + " " + instructionDetails +
                              " " + maxScore);
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC NewActivity @CourseID = {0}, @ModuleID = {1}, @activitytype = {2}, @instructiondetails = {3}, @maxpoints = {4}",
                    courseId, moduleId, type, instructionDetails, maxScore);
                TempData["SuccessMessage"] = "Learning activity added successfully!";
                return RedirectToAction("Activities", new { courseId = courseId, moduleId = moduleId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error adding learning activity: " + ex.Message;
                return View("AddLearningActivity1");
            }
        }
        
        public IActionResult FeedbackTrends()
        {
            // Call the stored procedure without parameters
            var feedbackTrends = _context.Emotional_feedbacks
                .FromSqlRaw("EXEC dbo.EmotionalTrendAnalysis")
                .ToList();

            // Pass the results to the view
            return View(feedbackTrends);
        }

        /*public IActionResult ManageCourses(CourseViewModel courses)
        {
                _context.Database.ExecuteSqlRaw(
                   "EXEC CourseViewModel @CourseID = {0}, @Title = {1}, @CourseDescription = {2}, @CanBeDeleted = {3}",
                   courses.CourseID,
                   courses.Title,
                   courses.CourseDescription,
                   !_context.Course_enrollments.Any(e => e.CourseID == courses.CourseID));

                return RedirectToAction("CourseViewModel");
        }*/

        /*public IActionResult ManageCourses()
        {
            var courses = _context.Courses
                .Select(course => new CourseViewModel
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    CourseDescription = course.course_description,
                    CanBeDeleted = !_context.Course_enrollments.Any(e => e.CourseID == course.CourseID)
                })
                .ToList();

            return View(courses);
        }*/


        /*[HttpPost]
        public IActionResult DeleteCourse(int courseId)
        {
            try
            {
                // Check if there are students enrolled in the course
                var hasEnrolledStudents = _context.Course_enrollments.Any(e => e.CourseID == courseId);
                if (hasEnrolledStudents)
                {
                    TempData["ErrorMessage"] = "Cannot delete the course. Students are enrolled in it.";
                    return RedirectToAction("Courses");
                }

                // Get the course and delete it
                var course = _context.Courses.FirstOrDefault(c => c.CourseID == courseId);
                if (course != null)
                {
                    _context.Courses.Remove(course);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Course deleted successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Course not found.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
            }

            return RedirectToAction("Courses");
        }*/

        //sec failed approach :(
        /*[HttpPost]
        public IActionResult DeleteCourse([FromBody] int courseId)
        {
            try
            {
                var course = _context.Courses
                    .Include(c => c.Course_enrollments) // Assuming there's an Enrollments navigation property
                    .FirstOrDefault(c => c.CourseID == courseId);

                if (course == null)
                {
                    return BadRequest("Course not found.");
                }

                if (course.Course_enrollments.Any())
                {
                    return BadRequest("Cannot delete a course that has enrolled students.");
                }

                _context.Courses.Remove(course);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }*/

        /*public IActionResult DeleteCourse(int courseId)
        {
            // Declare a variable to hold the output value for HasEnrollments
            var hasEnrollmentsParam = new SqlParameter("@HasEnrollments", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };

            // Execute the stored procedure with the output parameter
            _context.Database.ExecuteSqlRaw(
                "EXEC dbo.CheckCourseEnrollment @CourseID = {0}, @HasEnrollments = @HasEnrollments OUTPUT",
                courseId,
                hasEnrollmentsParam
            );

            // Retrieve the output value of HasEnrollments
            bool hasEnrollments = (bool)hasEnrollmentsParam.Value;

            // If there are enrollments, prevent deletion
            if (hasEnrollments)
            {
                TempData["ErrorMessage"] = "This course cannot be deleted because it has enrolled students.";
                return RedirectToAction("ManageCourses"); // Replace with your view for managing courses
            }

            // Delete the course if no enrollments exist
            var course = _context.Courses.FirstOrDefault(c => c.CourseID == courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course deleted successfully.";
            }

            return RedirectToAction("ManageCourses");
        }*/


        //another failed one :(
        /*public IActionResult DeleteCourse(int courseId)
        {
            var hasEnrollments = _context.Course_enrollments.Any(e => e.CourseID == courseId);

            if (hasEnrollments)
            {
                TempData["ErrorMessage"] = "This course cannot be deleted because it has enrolled students.";
                return RedirectToAction("ManageCourses");
            }

            var course = _context.Courses.FirstOrDefault(c => c.CourseID == courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course deleted successfully.";
            }

            return RedirectToAction("ManageCourses");
        }*/

        //tal3 el mo4kla feh esm method x_x
        public IActionResult DeleteCourse(int courseId)
        {
            // Check if there are any enrollments in the course
            var hasEnrollments = _context.Course_enrollments.Any(e => e.CourseID == courseId);

            if (hasEnrollments)
            {
                // If there are enrollments, set an error message and redirect to ManageCourses
                TempData["ErrorMessage"] = "This course cannot be deleted because it has enrolled students.";
                return RedirectToAction("Courses");
            }

            // Find the course in the database
            var course = _context.Courses.FirstOrDefault(c => c.CourseID == courseId);
            if (course != null)
            {
                // If course exists, delete it
                _context.Courses.Remove(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course deleted successfully.";
            }
            else
            {
                // If course is not found, set an error message
                TempData["ErrorMessage"] = "Course not found.";
            }

            // Redirect back to the ManageCourses page to show the result message
            return RedirectToAction("Courses");
        }

         // Action to view learners who completed prerequisites for a specific course
         public IActionResult CompletedPreq(int courseId)
         {
             // Create a list to hold learners who completed prerequisites
             List<Learner> learners = new List<Learner>();

             // Call the stored procedure to get learners who completed prerequisites
             learners = _context.Learners.FromSqlRaw("EXEC GetLearnersWithCompletedPrerequisites @CourseID={0}", courseId).ToList();

             // Return the view with the list of learners
             return View(learners);
         }

        public IActionResult ViewLearners(int courseId)
        {
            Console.WriteLine("Course ID: " + courseId);
            // Get the list of learners who completed the prerequisites for the course
            var learners = _context.Learners.FromSqlRaw("EXEC GetLearnersWithCompletedPrerequisites @CourseID={0}", courseId)
                .Select(l => new LearnerViewModel
                {
                    LearnerID = l.LearnerID,
                    FirstName = l.first_name,
                    LastName = l.last_name,
                    Gender = l.gender,
                    Email = l.email,
                    BirthDate = l.birth_date ?? DateOnly.MinValue, // Handle null birth_date
                    Country = l.country
                })
                .ToList() ?? new List<LearnerViewModel>();  // Ensure it's never null, return an empty list if no data


            //trying to debug but it still didn't display the list even with static loading
            /*var learners = new List<LearnerViewModel>
            {
                new LearnerViewModel { LearnerID = 1, FirstName = "John", LastName = "Doe" },
                new LearnerViewModel { LearnerID = 2, FirstName = "Jane", LastName = "Smith" }
            };

            // Log the learners list to check if it's empty
            Console.WriteLine("Learners count: " + learners.Count);
            foreach (var learner in learners)
            {
                Console.WriteLine($"Learner: {learner.LearnerID}, {learner.FirstName} {learner.LastName}");
            }*/
            Console.WriteLine("size of learners: " + learners.Count);

            return PartialView("CompletedPreq");

        }







    }
}