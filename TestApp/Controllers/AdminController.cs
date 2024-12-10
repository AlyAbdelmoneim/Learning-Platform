using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            // You can pass any data needed for the admin dashboard here
            return View();
        }
    }
}