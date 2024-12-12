using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;
using System.Linq;

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
                    return View(admin);  // Return the admin's profile data to the view
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
                    return View(admin);  // Pass the admin model to the edit view
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

    }
    
}
