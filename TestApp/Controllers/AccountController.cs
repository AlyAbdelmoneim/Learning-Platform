using Microsoft.AspNetCore.Mvc;
using TestApp.Context;
using TestApp.Models;
using TestApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _dbContext;

        public AccountController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel()); // Renders the SignUp.cshtml view
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if password and confirm password match
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("PasswordMismatch", "Passwords do not match.");
                    return View(model);
                }

                // Validate password strength (example: minimum length of 8 characters)
                if (model.Password.Length < 8)
                {
                    ModelState.AddModelError("WeakPassword", "Password must be at least 8 characters long.");
                    return View(model);
                }

                // Check if the email already exists in any of the tables
                var existingAdmin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.email == model.Email);
                var existingLearner = await _dbContext.Learners.FirstOrDefaultAsync(l => l.email == model.Email);
                var existingInstructor = await _dbContext.Instructors.FirstOrDefaultAsync(i => i.email == model.Email);

                if (existingAdmin != null || existingLearner != null || existingInstructor != null)
                {
                    ModelState.AddModelError("EmailExists", "The provided email is already in use.");
                    return View(model);
                }

                // Add to the appropriate table based on the selected role
                switch (model.Role)
                {
                    case "Admin":
                        var admin = new Admin
                        {
                            first_name = model.Username,
                            email = model.Email,
                            adminPassword = model.Password
                        };
                        _dbContext.Admins.Add(admin);
                        break;

                    case "Learner":
                        var learner = new Learner
                        {
                            first_name = model.Username,
                            email = model.Email,
                            adminPassword = model.Password
                        };
                        _dbContext.Learners.Add(learner);
                        break;

                    case "Instructor":
                        var instructor = new Instructor
                        {
                            instructor_name = model.Username,
                            email = model.Email,
                            adminPassword = model.Password
                        };
                        _dbContext.Instructors.Add(instructor);
                        break;

                    default:
                        ModelState.AddModelError("InvalidRole", "Invalid role selected.");
                        return View(model);
                }

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                // Success message
                TempData["SuccessMessage"] = "Sign-up successful! Please log in.";
                return RedirectToAction("Login");
            }
            else
            {
                // Output ModelState errors for debugging (optional)
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel()); // Ensure the model is passed correctly to the view
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check Admin table
                var admin = await _dbContext.Admins.FirstOrDefaultAsync(a => a.email == model.Email);
                if (admin != null)
                {
                    if (admin.adminPassword == model.Password)
                    {
                        HttpContext.Session.SetInt32("UserID", admin.AdminID);
                        HttpContext.Session.SetString("UserRole", "Admin");
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("InvalidPassword", "Incorrect password for Admin.");
                        return View(model);
                    }
                }

                // Check Learner table
                var learner = await _dbContext.Learners.FirstOrDefaultAsync(l => l.email == model.Email);
                if (learner != null)
                {
                    if (learner.adminPassword == model.Password)
                    {
                        HttpContext.Session.SetInt32("UserID", learner.LearnerID);
                        HttpContext.Session.SetString("UserRole", "Learner");
                        return RedirectToAction("LearnerDashboard", "Learner");
                    }
                    else
                    {
                        ModelState.AddModelError("InvalidPassword", "Incorrect password for Learner.");
                        return View(model);
                    }
                }

                // Check Instructor table
                var instructor = await _dbContext.Instructors.FirstOrDefaultAsync(i => i.email == model.Email);
                if (instructor != null)
                {
                    if (instructor.adminPassword == model.Password)
                    {
                        HttpContext.Session.SetInt32("UserID", instructor.InstructorID);
                        HttpContext.Session.SetString("UserRole", "Instructor");
                        return RedirectToAction("InstructorDashboard", "Instructor");
                    }
                    else
                    {
                        ModelState.AddModelError("InvalidPassword", "Incorrect password for Instructor.");
                        return View(model);
                    }
                }

                // Email not found in any table
                ModelState.AddModelError("EmailNotFound", "No account associated with this email.");
            }

            return View(model);
        }
    }
}
