﻿using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels.Users
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} 5-20 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        public string FullName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [EmailAddress(ErrorMessage = "You have to enter a valid email address")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime Birthday { get; set; }
        [MaxLength(100, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Address { get; set; } = "Unknown";
        public int? HospitalId { get; set; }
        [EnumDataType(typeof(Role), ErrorMessage = "{0} must be between 0 and 3")]
        public Role? Role { get; set; } = Domain.Enum.Role.USER;
    }
}
