﻿using Domain.Model.BloodRegister;
using Domain.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels
{
    public class RegisterBlood2ViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Note is required")]
        public string Note { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Status must be between 0 and 5")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "BloodId is required")]
        public int BloodId { get; set; } 
        [Required(ErrorMessage = "User is required")]
        public string UserId { get; set; }
        public DateTime? TimeSign { get; set; } = DateTime.MaxValue;
        [Required(ErrorMessage = "HospitalId is required")]
        public int HospitalId { get; set; } 
    }
}