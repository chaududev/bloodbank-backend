﻿using Domain.Model.BloodRegister;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Model.Users
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; private set; }
        public DateTime Birthday{ get; private set; }
        [MaxLength(100)]
        public string Address { get; private set; } = "Unknown";
        [JsonIgnore]
        public virtual List<Register> Register { get; private set; }
        public int? HospitalId { get; private set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital? Hospital { get; private set; }
        public User()
        {
        }
        public User(string userName, string fullName, string email, DateTime birthday, int? hospitalId, string address)
        {
            Update(userName,fullName, email??"Unknown@abc.com", birthday,hospitalId, address??"Unknown");
            EmailConfirmed = true;
            Register = new List<Register>();
        }
        public void Update(string userName,string fullName, string email,DateTime birthday, int? hospitalId, string address)
        {
            FullName = fullName.Trim();
            UserName = userName.Trim();
            Email = email.Trim();
            Birthday = birthday;
            HospitalId = hospitalId ?? 1;
            Address = address.Trim();

        }
    }
}
