using Domain.Model.BloodRegister;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model.Users
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string FullName { get; private set; }
        public DateTime Birthday{ get; private set; }
        [MaxLength(100)]
        public string Address { get; private set; }
        public virtual List<Register> Register { get; private set; }
    }
}
