using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} 5-20 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
