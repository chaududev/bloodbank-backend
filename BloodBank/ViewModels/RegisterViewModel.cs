using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels
{
	public enum Role
	{
		USER,
        HOSPITAL,
        STAFF,
        ADMIN
	}
	public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Use 5-20 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [EmailAddress(ErrorMessage = "You have to enter a valid email address")]
        public string Email { get; set; }
        public DateTime? Birthday { get; set; } = DateTime.MinValue;
        public string? Address { get; set; } = "Unknown";
        public int? HospitalId { get; set; } = 1;
        [EnumDataType(typeof(Role), ErrorMessage = "Role must be between 0 and 3")]
        public Role? Role { get; set; } = ViewModels.Role.USER;
    }
}
