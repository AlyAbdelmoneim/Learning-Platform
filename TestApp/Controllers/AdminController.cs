using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;
using System.Linq;
using TestApp.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace TestApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }

        // Admin Dashboard (GET)
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            // Assuming the admin is logged in and the UserID is stored in session.
            var adminId = HttpContext.Session.GetInt32("UserID");

            if (adminId.HasValue)
            {
                var admin = _context.Admins.FirstOrDefault(a => a.AdminID == adminId.Value);
                if (admin != null)
                {
                    return View(admin); // Return the admin's profile data to the view
                }
            }

            TempData["ErrorMessage"] = "Admin not found or not logged in.";
            return RedirectToAction("Login", "Account");
        }

        // Edit Admin Profile (GET)
        [HttpGet]
        public IActionResult EditAdminProfile()
        {
            var adminId = HttpContext.Session.GetInt32("UserID");

            if (adminId.HasValue)
            {
                var admin = _context.Admins.FirstOrDefault(a => a.AdminID == adminId.Value);
                if (admin != null)
                {
                    return View(admin); // Pass the admin model to the edit view
                }
            }

            TempData["ErrorMessage"] = "Admin not found or not logged in.";
            return RedirectToAction("AdminDashboard");
        }

        // Edit Admin Profile (POST)
        [HttpPost]
        public IActionResult EditAdminProfile(Admin updatedAdmin)
        {
            var adminId = HttpContext.Session.GetInt32("UserID");

            if (ModelState.IsValid)
            {
                var admin = _context.Admins.FirstOrDefault(a => a.AdminID == adminId);
                if (admin != null)
                {
                    admin.first_name = updatedAdmin.first_name;
                    admin.last_name = updatedAdmin.last_name;
                    admin.email = updatedAdmin.email;

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Profile updated successfully.";
                    return RedirectToAction("AdminDashboard");
                }
            }

            TempData["ErrorMessage"] = "Invalid profile data for admin. Please check your inputs.";
            return View(updatedAdmin);
        }

        // Admin Dashboard (GET)
        [HttpGet]
        public IActionResult LearnersPage()
        {
            var learners = _context.Learners.ToList();
            return View(learners);
        }

        // Instructors Page
        [HttpGet]
        public IActionResult InstructorsPage()
        {
            var instructors = _context.Instructors.ToList();
            return View(instructors);
        }

        // View Learner's Personalization Profile
        [HttpGet]
        public IActionResult PersonalizationProfile(int learnerId)
        {
            var personalizationProfiles = _context.PersonalizationProfiles
                .Where(p => p.LearnerID == learnerId)
                .ToList();
            return View(personalizationProfiles);
        }

        // Delete Learner
        [HttpPost]
        public IActionResult DeleteLearner(int id)
        {
            var learner = _context.Learners.Find(id);
            if (learner != null)
            {
                _context.Learners.Remove(learner);
                _context.SaveChanges();
            }

            return RedirectToAction("LearnersPage");
        }

        // Delete Instructor
        [HttpPost]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }

            return RedirectToAction("InstructorsPage");
        }

        // Delete Personalization Profile
        [HttpPost]
        public IActionResult DeletePersonalizationProfile(int id, int learnerId)
        {
            var profile = _context.PersonalizationProfiles
                .FirstOrDefault(p => p.ProfileID == id && p.LearnerID == learnerId);

            if (profile != null)
            {
                _context.PersonalizationProfiles.Remove(profile);
                _context.SaveChanges();
            }

            return RedirectToAction("PersonalizationProfile", new { learnerId });
        }

        // Delete Admin Profile
        [HttpPost]
        [ActionName("DeleteAdminProfile")]
        public IActionResult DeleteAdminAccount()
        {
            var adminId = HttpContext.Session.GetInt32("UserID");
            var admin = _context.Admins.FirstOrDefault(i => i.AdminID == adminId);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Your account has been successfully deleted.";
                return RedirectToAction("Login", "Account");
            }

            TempData["ErrorMessage"] = "admin not found.";
            return RedirectToAction("AdminDashboard", new { AdminID = adminId });
        }

        public IActionResult Courses()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Modules(int courseID)
        {
            Console.WriteLine("Course ID: " + courseID);
            var modules = _context.Modules.FromSqlRaw("Exec dbo.GetModulesForCourse @CourseID = {0}", courseID)
                .ToList();
            Console.WriteLine("In modules: courseID" + courseID);
            IntDTO courseId = new IntDTO();
            courseId.Value = courseID;
            return View(Tuple.Create(modules, courseId));
        }

        public IActionResult DiscussionForums(int courseID, int moduleID)
        {
            var forums = _context.Discussion_forums
                .FromSqlRaw("Exec dbo.GetDiscussionForums @CourseID = {0}, @ModuleID = {1}", courseID, moduleID)
                .ToList();
            Console.WriteLine("forums size" + forums.Count);
            Console.WriteLine("in discussion : courseID" + courseID + "moduleID" + moduleID);

            IntDTO courseId = new IntDTO();
            courseId.Value = courseID;
            IntDTO moduleId = new IntDTO();
            moduleId.Value = moduleID;
            Console.WriteLine("in discussion using DTO courseID: " + courseId.Value + ", moduleID: " + moduleId.Value);
            return View(Tuple.Create(forums, courseId, moduleId));
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
            // ViewData["CourseID"] = courseID;
            // ViewData["ModuleID"] = moduleID;
            Console.WriteLine("in add discussion1 forum: courseID" + courseID + "moduleID" + moduleID);
            Console.WriteLine("Course ID: " + courseID + ", Module ID: " + moduleID);
            IntDTO courseId = new IntDTO();
            courseId.Value = courseID;
            IntDTO moduleId = new IntDTO();
            moduleId.Value = moduleID;
            return View(Tuple.Create(courseId, moduleId));
        }

        [HttpPost]
        public IActionResult AddDiscussionForum(int courseId, int moduleId, string title, string description)
        {
            Console.WriteLine("in add discussion2 forum: courseID" + courseId + "moduleID" + moduleId);
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "Exec dbo.CreateDiscussion @ModuleID = {0}, @CourseID = {1}, @title = {2}, @description = {3}",
                    moduleId, courseId, title, description);
                TempData["SuccessMessage"] = "Discussion forum added successfully!";
                return RedirectToAction("DiscussionForums", new { courseID = courseId, moduleID = moduleId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error adding discussion forum: " + ex.Message;
                return View();
            }
        }


        //the working one 
        // [HttpGet]
        // public IActionResult Notifications()
        // {
        //     var notifications = _context.SystemNotifications.ToList();
        //     return View(notifications);
        // }


        //testing this one to show all notifications for the admin 
        //
        // public IActionResult Notifications()
        // {
        //     var notifications = _context.SystemNotifications.FromSqlRaw("EXEC dbo.ViewAllNotifications").ToList();
        //     return View(notifications);
        // }
        //
        //
        // // Action to mark a notification as read
        // [HttpPost]
        // public IActionResult MarkAsRead(int notificationId)
        // {
        //     var notification = _context.SystemNotifications.FirstOrDefault(n => n.ID == notificationId);
        //
        //     if (notification == null)
        //     {
        //         TempData["ErrorMessage"] = "Notification not found.";
        //         return RedirectToAction("Notifications");
        //     }
        //
        //     notification.ReadStatus = true; // Mark the notification as read
        //     _context.SaveChanges(); // Save changes to the database
        //
        //     TempData["SuccessMessage"] = "Notification marked as read.";
        //     return RedirectToAction("Notifications"); // Redirect back to the notifications page
        // }

        public IActionResult Leaderboard(int leaderboardId)
        {
            Console.WriteLine("Leaderboard Id is " + leaderboardId);
            var leaderboard = _context.RankingViewModels
                .FromSqlRaw("EXEC dbo.LeaderboardRank @LeaderboardID = {0}", leaderboardId).ToList();

            if (leaderboard == null || !leaderboard.Any())
            {
                return RedirectToAction("LeaderBoard");
            }

            return View(leaderboard);
        }


        //the working one 
        // [HttpGet]
        // public IActionResult Notifications()
        // {
        //     var notifications = _context.SystemNotifications.ToList();
        //     return View(notifications);
        // }


        //testing this one to show all notifications for the admin 

        public IActionResult Notifications()
        {
            var notifications = _context.SystemNotifications.FromSqlRaw("EXEC dbo.ViewAllNotifications").ToList();
            return View(notifications);
        }


        // Action to mark a notification as read
        [HttpPost]
        public IActionResult MarkAsRead(int notificationId)
        {
            var notification = _context.SystemNotifications.FirstOrDefault(n => n.ID == notificationId);

            if (notification == null)
            {
                TempData["ErrorMessage"] = "Notification not found.";
                return RedirectToAction("Notifications");
            }

            notification.ReadStatus = true; // Mark the notification as read
            _context.SaveChanges(); // Save changes to the database

            TempData["SuccessMessage"] = "Notification marked as read.";
            return RedirectToAction("Notifications"); // Redirect back to the notifications page
        }

        public IActionResult FeedbackTrends()
        {
            var feedbackTrends = _context.Emotional_feedbacks
                .FromSqlRaw("EXEC dbo.EmotionalTrendAnalysis")
                .ToList();

            return View(feedbackTrends);
        }
    }
}