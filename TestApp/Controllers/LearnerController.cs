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
            // You can pass any data needed for the learner dashboard here
            var data = _context.Learners.FromSqlRaw("EXEC dbo.ViewInfo @LearnerID = {0}", 1).ToList();

            // Debugging: Log or check if data is empty
            if (data.Count == 0)
            {
                Console.WriteLine("No data found for learner.");
            }

            return View(data);
        }

    }
}