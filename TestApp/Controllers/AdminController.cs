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

        // Admin Dashboard
        [HttpGet]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        // Learners Page
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

    }
}
