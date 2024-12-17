using System.ComponentModel.DataAnnotations;

namespace TestApp.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username can't be longer than 100 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [StringLength(255, ErrorMessage = "Email can't be longer than 255 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        [StringLength(50, ErrorMessage = "Role can't be longer than 50 characters")]
        public string Role { get; set; } // Admin, Learner, or Instructor

        // Optional: Trim spaces to avoid leading/trailing space errors
        public SignUpViewModel()
        {
            Username = Username?.Trim();
            Email = Email?.Trim();
            Password = Password?.Trim();
            ConfirmPassword = ConfirmPassword?.Trim();
        }
    }
}