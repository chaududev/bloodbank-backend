using Domain.Model.BloodRegister;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? HospitalId { get; private set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital? Hospital { get; private set; }
        public User()
        {
        }
        public User(string userName, string fullName, string? email, DateTime? birthday, string? address)
        {
            Update(userName,fullName, email, birthday, address);
            EmailConfirmed = true;
            Register = new List<Register>();
        }
        public void Update(string userName,string fullName, string? email,DateTime? birthday, string? address)
        {
            FullName = fullName.Trim();
            UserName = userName.Trim();
            Email = email.Trim() ?? "Unknown@abc.com";
            Birthday = birthday;
            Address = address.Trim() ?? "Unknown";

        }
        public void Set(string fullName)
        {
            FullName = fullName.Trim();
        }
        public void SetHospital(int hospitalId)
        {
            HospitalId= hospitalId;
        }
    }
}
