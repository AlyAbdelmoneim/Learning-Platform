using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]
        [HttpPost]
        public IActionResult EditInstructorProfile(Instructor updatedInstructor)
        {
            if (ModelState.IsValid)
            {
                var instructor = _context.Instructors.FirstOrDefault(i => i.InstructorID == updatedInstructor.InstructorID);
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

            TempData["ErrorMessage"] = "Invalid profile data. Please check your inputs.";
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
    }
    
}