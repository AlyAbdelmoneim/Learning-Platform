using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;
using System.Linq;

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
            var learnerID  = HttpContext.Session.GetInt32("UserID");
            // var learnerIdString = HttpContext.Session.GetString("LearnerID");
            // if (string.IsNullOrEmpty(learnerIdString) || !int.TryParse(learnerIdString, out int learnerId))
            // {
            //     TempData["ErrorMessage"] = "Error: Learner session is not valid.";
            //     return RedirectToAction("LearnerDashboard");
            // }

             var learner = _context.Learners.FirstOrDefault(l => l.LearnerID == learnerID);
            if (learner!= null)
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
            if (ModelState.IsValid) {
                newProfile.LearnerID = learnerId.Value; 
                Console.WriteLine("value of learner id" + learnerId.Value);// Associate the profile with the current learner
                _context.PersonalizationProfiles.Add(newProfile);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Personalization profile added successfully.";
                return RedirectToAction("PersonalizationProfile");
            } else {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }


            TempData["ErrorMessage"] = "Failed to add personalization profile.";
            return View(newProfile); // Return to the form if validation fails
        }
    }
    
}
