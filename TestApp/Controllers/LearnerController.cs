using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace TestApp.Controllers
{
    public class LearnerController : Controller
    {
        private readonly MyDbContext _context;

        // Constructor to inject the context
        public LearnerController(MyDbContext context)
        {
            _context = context;
        }

        // Learner Dashboard - Fetch data specific to the logged-in learner
        public IActionResult LearnerDashboard()
        {
            // Retrieve the learner ID from the session
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if no learnerId is found in session
            }

            // Fetch learner data using raw SQL query (adjust as necessary)
            var data = _context.Learners
                .FromSqlRaw("EXEC dbo.ViewInfo @LearnerID = {0}", learnerId)
                .ToList();

            if (data.Count == 0)
            {
                Console.WriteLine("No data found for learner.");
            }

            return View(data); // Pass the data to the View
        }

        // Personalization Profile - Display the personalization profile of the learner
        [Route("Learner/PersonalizationProfile")]
        public IActionResult PersonalizationProfile()
        {
            // Retrieve the learner ID from the session
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if no learnerId is found in session
            }

            // Fetch personalization profiles for the specific learner
            var personalizations = _context.PersonalizationProfiles
                .Where(p => p.LearnerID == learnerId)
                .ToList();

            return View(personalizations); // Pass the personalization profiles to the view
        }

        // Delete Personalization Profile - Delete the selected personalization profile
        [HttpPost]
        [Route("Learner/DeletePersonalization/{id}")]
        public IActionResult DeletePersonalization(int id)
        {
            // Retrieve the learner ID from the session
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if no learnerId is found in session
            }

            // Find the personalization profile by ID and learner ID
            var personalization = _context.PersonalizationProfiles
                .FirstOrDefault(p => p.ProfileID == id && p.LearnerID == learnerId);

            if (personalization != null)
            {
                _context.PersonalizationProfiles.Remove(personalization);
                _context.SaveChanges(); // Save changes to remove the profile from the database
            }

            // Redirect to the personalization profile page after deletion
            return RedirectToAction("PersonalizationProfile");
        }

        [HttpPost]
        [HttpPost]
        public IActionResult DeleteAccount()
        {
            var learnerID = HttpContext.Session.GetInt32("UserID");
            // var learnerIdString = HttpContext.Session.GetString("LearnerID");
            // if (string.IsNullOrEmpty(learnerIdString) || !int.TryParse(learnerIdString, out int learnerId))
            // {
            //     TempData["ErrorMessage"] = "Error: Learner session is not valid.";
            //     return RedirectToAction("LearnerDashboard");
            // }

            var learner = _context.Learners.FirstOrDefault(l => l.LearnerID == learnerID);
            if (learner != null)
            {
                _context.Learners.Remove(learner);
                _context.SaveChanges();
                HttpContext.Session.Clear(); // Clear session after deletion
                TempData["SuccessMessage"] = "Your account has been deleted.";
                return RedirectToAction("Login", "Account"); // Redirect to login page
            }

            TempData["ErrorMessage"] = "Error deleting account. Please try again.";
            return RedirectToAction("LearnerDashboard");
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            // Assuming the user is authenticated and their LearnerID is stored in the session
            var learnerId = HttpContext.Session.GetInt32("UserID");
            var learner = _context.Learners.FirstOrDefault(l => l.LearnerID == learnerId);

            if (learner == null)
            {
                return RedirectToAction("LearnerDashboard");
            }

            return View(learner);
        }

        [HttpPost]
        public IActionResult EditProfile(Learner updatedLearner)
        {
            if (ModelState.IsValid)
            {
                var learner = _context.Learners.FirstOrDefault(l => l.LearnerID == updatedLearner.LearnerID);
                if (learner != null)
                {
                    learner.first_name = updatedLearner.first_name;
                    learner.last_name = updatedLearner.last_name;
                    learner.birth_date = updatedLearner.birth_date;
                    learner.gender = updatedLearner.gender;
                    learner.cultural_background = updatedLearner.cultural_background;

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Profile updated successfully.";
                    return RedirectToAction("LearnerDashboard");
                }
            }

            TempData["ErrorMessage"] = "Invalid profile data. Please check your inputs.";
            return View(updatedLearner);
        }

        [HttpGet]
        [Route("Learner/AddPersonalizationProfile")]
        public IActionResult AddPersonalizationProfile()
        {
            Console.WriteLine("wtf");
            // Check if the learner is logged in
            var learnerId = HttpContext.Session.GetInt32("UserID");
            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            // Prepare an empty model for the view
            var model = new PersonalizationProfile
            {
                LearnerID = learnerId.Value // Set the learner ID
            };
            Console.WriteLine("wft2");
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                Console.WriteLine("wtf in not valid");
            }

            Console.WriteLine("wft3");


            return View(model);
        }

        [HttpPost]
        [Route("Learner/AddPersonalizationProfile")]
        public IActionResult AddPersonalizationProfile(PersonalizationProfile newProfile)
        {
            Console.WriteLine("start of add method");
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            Console.Write("before is model valid");
            if (ModelState.IsValid)
            {
                newProfile.LearnerID = learnerId.Value;
                Console.WriteLine("value of learner id" +
                                  learnerId.Value); // Associate the profile with the current learner
                _context.PersonalizationProfiles.Add(newProfile);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Personalization profile added successfully.";
                return RedirectToAction("PersonalizationProfile");
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }


            TempData["ErrorMessage"] = "Failed to add personalization profile.";
            return View(newProfile); // Return to the form if validation fails
        }

        public IActionResult LearnerGoals()
        {
            // Retrieve the learner ID from the session
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if no learnerId is found in session
            }
            var goals = _context.Learning_goals.FromSqlRaw("EXEC dbo.MyGoals @LearnerID = {0}", learnerId).ToList();
            return View(goals); // Pass the goals to the View
        }
        // GET: AddGoal
        public IActionResult AddGoal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGoal(string GoalDescription, DateTime Deadline, string GoalStatus)
        {
            // Retrieve the learner ID from the session
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if no learnerId is found in session
            }

            try
            {
                // Execute the stored procedure
                _context.Database.ExecuteSqlRaw(
                    "EXEC CreateAndAssignGoal @LearnerID = {0}, @GoalStatus = {1}, @Deadline = {2}, @GoalDescription = {3}",
                    learnerId.Value, GoalStatus, Deadline, GoalDescription);

                TempData["SuccessMessage"] = "Goal added successfully!";
                return RedirectToAction("LearnerGoals");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error adding goal: {ex.Message}";
                return View();
            }
        }
        
        [Route("LearningPath/{profileID}")]
        public IActionResult LearningPath(int profileID)
        {
            // Retrieve the learner ID from the session
            var learnerId = HttpContext.Session.GetInt32("UserID");
            Console.WriteLine("Received ProfileID: " + profileID);  // Debugging line

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if no learnerId is found in session
            }

            // Execute the stored procedure to retrieve learning path data
            var path = _context.Learning_paths.FromSqlRaw("EXEC dbo.CurrentPath @LearnerID = {0}, @ProfileID = {1}", learnerId, profileID).ToList();
            
            Console.WriteLine("size of path" + path.Count + " for learner id" + learnerId + " and profile id" + profileID);

            return View(path); // Pass the learning paths to the view
        }
        public IActionResult Courses()
        {
            var learnerId = HttpContext.Session.GetInt32("UserID");
            var courses = _context.Courses.FromSqlRaw("Exec dbo.EnrolledCourses @LearnerID = {0}", learnerId).ToList();
            return View(courses);
        }
        public IActionResult Modules(int courseID)
        {
            Console.WriteLine("Course ID: " + courseID);
            var modules = _context.Modules.FromSqlRaw("Exec dbo.GetModulesForCourse @CourseID = {0}", courseID).ToList();
            return View(modules);
        }
        public IActionResult DiscussionForums(int courseID, int moduleID)
        {
            var forums = _context.Discussion_forums.FromSqlRaw("Exec dbo.GetDiscussionForums @CourseID = {0}, @ModuleID = {1}", courseID, moduleID).ToList();
            return View(forums);
        }
        public IActionResult Posts(int forumID)
        {
            var posts = _context.LearnerDiscussions.FromSqlRaw("Exec dbo.GetPostsForForum @ForumID = {0}" , forumID).ToList();
            var tuple = new Tuple<List<LearnerDiscussion>, int>(posts, forumID);
            return View(tuple);
        }
        public IActionResult AddPost(int forumID)
        {
            Console.WriteLine("coming forum id: " + forumID);
            return View(forumID); // Display the AddPost view
        }

        [HttpPost]
        public IActionResult AddPost(String forumID, String content)
        {
            var learnerID = HttpContext.Session.GetInt32("UserID");
            if (!learnerID.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }
            int forumID2 = Int32.Parse(forumID);
            Console.WriteLine("forum id: " + forumID + " content: " + content);
            _context.Database.ExecuteSqlRaw("EXECUTE dbo.Post @LearnerID = {0}, @DiscussionID = {1}, @Post = {2}", learnerID, forumID2, content);
            return RedirectToAction("Posts", new { forumID = forumID2 });
        }
        
        //new code
        // View notifications for a learner
        public IActionResult Notifications()
        {
            var learnerID = HttpContext.Session.GetInt32("UserID");
            
            if (!learnerID.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }
            
            var notifications = _context.SystemNotifications
                .FromSqlRaw("EXEC dbo.GetNotifications @LearnerID = {0}", learnerID)
                .ToList();
            Console.WriteLine("EL COUNT AHOHHHHHH");
            Console.WriteLine(notifications.Count);
            Console.WriteLine(learnerID);
            return View(notifications);
        }

        // Send reminders for upcoming goals
        [HttpPost]
        public IActionResult SendGoalReminders()
        {
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GoalReminder", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LearnerID", learnerId);

                    command.ExecuteNonQuery();
                }
            }

            TempData["Message"] = "Goal reminders sent successfully.";
            return RedirectToAction("Notifications");
        }

        // Mark a notification as read
        [HttpPost]
        public IActionResult MarkNotificationAsRead(int notificationId)
        {
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("NotificationUpdate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LearnerID", learnerId);
                    command.Parameters.AddWithValue("@NotificationID", notificationId);
                    command.Parameters.AddWithValue("@ReadStatus", true);

                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Notifications");
        }
        public IActionResult MarkNotificationAsUnRead(int notificationId)
        {
            var learnerId = HttpContext.Session.GetInt32("UserID");

            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("NotificationUpdate", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LearnerID", learnerId);
                    command.Parameters.AddWithValue("@NotificationID", notificationId);
                    command.Parameters.AddWithValue("@ReadStatus", false);

                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Notifications");
        }
        
        [HttpGet]
        public IActionResult AddEmotionalFeedback(int activityId)
        {
            var learnerId = HttpContext.Session.GetInt32("UserID");
            if (!learnerId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new Emotional_feedback
            {
                activityID = activityId,
                LearnerID = learnerId.Value
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddEmotionalFeedback(Emotional_feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }

            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("AddEmotionalFeedback", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LearnerID", feedback.LearnerID);
                    command.Parameters.AddWithValue("@ActivityID", feedback.activityID);
                    command.Parameters.AddWithValue("@EmotionalState", feedback.emotional_state);

                    command.ExecuteNonQuery();
                }
            }

            TempData["SuccessMessage"] = "Your feedback has been recorded successfully!";
            return RedirectToAction("LearnerDashboard");
        }
        
        public IActionResult Leaderboard(int leaderboardId)
        {
            Console.WriteLine("Leaderboard Id is " + leaderboardId);
            var leaderboard = _context.RankingViewModels.FromSqlRaw("EXEC dbo.LeaderboardRank @LeaderboardID = {0}", leaderboardId).ToList();

            if (leaderboard == null)
            {
                return RedirectToAction("LearnerDashboard");
            }

            return View(leaderboard);
        }

        
        

    }
}