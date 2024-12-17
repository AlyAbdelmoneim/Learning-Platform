
namespace TestApp.Models.ViewModels
{
    public partial class LearnerViewModel
    {
        public int LearnerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Country { get; set; }
    }
}
