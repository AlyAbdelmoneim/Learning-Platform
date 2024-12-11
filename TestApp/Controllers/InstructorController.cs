using Microsoft.AspNetCore.Mvc;
using TestApp.Context;

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
            var instructorId = HttpContext.Session.GetInt32("UserID");
            if (instructorId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}