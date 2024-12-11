using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;

namespace TestApp.Controllers
{
    public class LearnerController : Controller
    {
        private readonly MyDbContext _context = new MyDbContext();
        public IActionResult LearnerDashboard()
        {
            
            var learnerId = HttpContext.Session.GetInt32("UserID");
            // You can pass any data needed for the learner dashboard here
            var data = _context.Learners.FromSqlRaw("EXEC dbo.ViewInfo @LearnerID = {0}", learnerId).ToList();

            // Debugging: Log or check if data is empty
            if (data.Count == 0)
            {
                Console.WriteLine("No data found for learner.");
            }

            return View(data);
        }
        [Route("Learner/PersonalizationProfile")]
        public IActionResult PersonalizationProfile()
        {
            var learnerId = HttpContext.Session.GetInt32("UserID");
            // Assuming you have a Personalizations table with a foreign key to the Learner
            var personalizations = _context.PersonalizationProfiles
                .Where(p => p.LearnerID == learnerId)
                .ToList();

            return View(personalizations);
        }
        [HttpPost]
        [Route("Learner/DeletePersonalization/{id}")]
        public IActionResult DeletePersonalization(int id)
        {
            var learnerId = HttpContext.Session.GetInt32("UserID");
            var personalization = _context.PersonalizationProfiles.Find(id, learnerId);
            if (personalization != null)
            {
                _context.PersonalizationProfiles.Remove(personalization);
                _context.SaveChanges();
            }

            return RedirectToAction("PersonalizationProfile");
        }



    }
}