using Domain.Model.BloodRegister;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model.Users
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; private set; }
        public DateTime? Birthday{ get; private set; }
        [MaxLength(100)]
        public string? Address { get; private set; } = "Unknown";
        public virtual List<Register> Register { get; private set; }
        public User()
        {
        }
        public void Set(string fullName)
        {
            FullName = fullName.Trim();
            Register = new List<Register>();
        }
    }
}
