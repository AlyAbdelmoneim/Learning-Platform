using Microsoft.AspNetCore.Mvc;
using TestApp.Context;
using TestApp.Models;
using TestApp.Models.ViewModels;
using TestApp.Context;
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
            return View(); // Renders the SignUp.cshtml view
        }

        [HttpPost]
public async Task<IActionResult> SignUp(SignUpViewModel model)
{
    if (ModelState.IsValid)
    {
        // Hash the password
        var passwordHasher = new PasswordHasher<string>();
        string hashedPassword = passwordHasher.HashPassword(model.Email, model.Password); // Hash password using email as identifier

        // Check if the email already exists in any of the tables
        var existingAdmin = await _dbContext.Admins
            .FirstOrDefaultAsync(a => a.email == model.Email);
        
        var existingLearner = await _dbContext.Learners
            .FirstOrDefaultAsync(l => l.email == model.Email);
        
        var existingInstructor = await _dbContext.Instructors
            .FirstOrDefaultAsync(i => i.email == model.Email);

        if (existingAdmin != null || existingLearner != null || existingInstructor != null)
        {
            ModelState.AddModelError("", "Email is already taken.");
            return View(model); // Return to sign-up page if email is taken
        }

        // Add to the appropriate table based on the selected role
        switch (model.Role)
        {
            case "Admin":
                var admin = new Admin
                {
                    first_name = model.Username,
                    email = model.Email,
                    adminPassword = hashedPassword // Store the hashed password
                };
                _dbContext.Admins.Add(admin);
                break;

            case "Learner":
                var learner = new Learner
                {
                    first_name = model.Username,
                    email = model.Email,
                    adminPassword = hashedPassword // Store the hashed password
                };
                _dbContext.Learners.Add(learner);
                break;

            case "Instructor":
                var instructor = new Instructor
                {
                    instructor_name = model.Username,
                    email = model.Email,
                    adminPassword = hashedPassword // Store the hashed password
                };
                _dbContext.Instructors.Add(instructor);
                break;

            default:
                ModelState.AddModelError("", "Invalid role selected");
                return View(model);
        }

        // Save changes to the database
        await _dbContext.SaveChangesAsync();

        // Ensure the redirection happens after saving data
        TempData["SuccessMessage"] = "Sign-up successful! Please log in.";
        return RedirectToAction("Login", "AccountController"); // Redirect to Login page
    }

    return View(model); // Return the same view if model is invalid or errors exist
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
                var passwordHasher = new PasswordHasher<string>();

                // Check in the Admin table
                var admin = await _dbContext.Admins
                    .FirstOrDefaultAsync(a => a.email == model.Email);

                if (admin != null && passwordHasher.VerifyHashedPassword(admin.first_name, admin.adminPassword, model.Password) != PasswordVerificationResult.Failed)
                {
                    return RedirectToAction("AdminDashboard"); // Redirect to Admin dashboard
                }

                // Check in the Learner table
                var learner = await _dbContext.Learners
                    .FirstOrDefaultAsync(l => l.email == model.Email);

                if (learner != null && passwordHasher.VerifyHashedPassword(learner.first_name, learner.adminPassword, model.Password) != PasswordVerificationResult.Failed)
                {
                    return RedirectToAction("LearnerDashboard"); // Redirect to Learner dashboard
                }

                // Check in the Instructor table
                var instructor = await _dbContext.Instructors
                    .FirstOrDefaultAsync(i => i.email == model.Email);

                if (instructor != null && passwordHasher.VerifyHashedPassword(instructor.instructor_name, instructor.adminPassword, model.Password) != PasswordVerificationResult.Failed)
                {
                    return RedirectToAction("InstructorDashboard"); // Redirect to Instructor dashboard
                }

                // If no match found, add an error
                ModelState.AddModelError("", "Invalid login attempt");
            }

            return View(model);
        }
    }
}
