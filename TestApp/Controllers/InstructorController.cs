using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;
using TestApp.Models.ViewModels;

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
            var leaderboard = _context.RankingViewModels.FromSqlRaw("EXEC dbo.LeaderboardRank @LeaderboardID = {0}", leaderboardId).ToList();

            if (leaderboard == null || !leaderboard.Any())
            {
                return RedirectToAction("LearnerDashboard");
            }

            return View(leaderboard);
        }

        public IActionResult FeedbackTrends()
        {
            // Call the stored procedure without parameters
            var feedbackTrends = _context.Emotional_feedbacks
                .FromSqlRaw("EXEC dbo.EmotionalTrendAnalysisIns")
                .ToList();

            // Pass the results to the view
            return View(feedbackTrends);
        }




    }
}