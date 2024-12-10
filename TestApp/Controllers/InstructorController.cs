using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult InstructorDashboard()
        {
            // You can pass any data needed for the instructor dashboard here
            return View();
        }
    }
}