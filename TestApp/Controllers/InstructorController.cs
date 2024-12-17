using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;

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
                    return View(instructor);  // Pass the instructor model to the view
                }
                else
                {
                    TempData["ErrorMessage"] = "Instructor not found.";
                    return RedirectToAction("Login", "Account");
                }
            }

            TempData["ErrorMessage"] = "You must be logged in to access the instructor dashboard.";
            return RedirectToAction("Login", "Account");  // Redirect to login page if no session
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
            var learners = _context.Learners.ToList();
            return View(learners);
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
                TempData["ErrorMessage"] = $"Error adding path: {ex.Message} \n\n learnerId: {LearnerId}, profileId: {ProfileId}, customContent: {CustomContent}, adaptiveRules: {AdaptiveRules}";
                return View();
            }
        }
        public IActionResult Courses(){
            var courses = _context.Courses.FromSqlRaw("EXEC InstructorCourses {0}", HttpContext.Session.GetInt32("UserID")).ToList();
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
                _context.Database.ExecuteSqlRaw("Exec dbo.CreateDiscussion @ModuleID = {0}, @CourseID = {1}, @title = {2}, @description = {3}", forum.ModuleID, forum.CourseID, forum.title, forum.forum_description);
                TempData["SuccessMessage"] = "Discussion forum added successfully!";
                return RedirectToAction("DiscussionForums", new { courseID = forum.CourseID, moduleID = forum.ModuleID });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error adding discussion forum: " + ex.Message;
                return View();
            }
        }

        public IActionResult AssessmentsListInstruct(int courseID, int moduleID)
        {
            var learnerID = HttpContext.Session.GetInt32("UserID");
            if (learnerID == null)
            {
                Console.WriteLine("LearnerID is null");
                return View("Error");
            }

            var assessmentList = _context.AssessmentDTOs
                .FromSqlRaw("EXECUTE dbo.AssessmentListModified @LearnerID = {0}, @CourseID = {1}, @ModuleID = {2}",
                            learnerID, courseID, moduleID)
                .ToList();

            return View(assessmentList);
        }

        public IActionResult HighestGrades()
        {
            var highestGrades = _context.HighestGradeDTOs
                .FromSqlRaw("EXEC Highestgrade")
                .ToList();

            return View(highestGrades);
        }

        public IActionResult AssessmentAnalysis()
        {
            var assessments = _context.AssessmentDTOs
                .FromSqlRaw("EXEC dbo.AssessmentAnalysis")
                .ToList();

            return View(assessments);
        }

        public IActionResult GoToCreateAssessment()
        {
            var viewModel = new CreateAssessmentViewModel
            {
                Courses = _context.Courses.Select(c => new SelectListItem
                {
                    Value = c.CourseID.ToString(),
                    Text = c.Title
                }).ToList(),
                Modules = _context.Modules.Select(m => new SelectListItem
                {
                    Value = m.ModuleID.ToString(),
                    Text = m.Title
                }).ToList()
            };

            return View(viewModel);
        }
    }
} 