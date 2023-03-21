using Domain.Model.Users;

namespace BloodBank.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
		public string Email { get; set; }
		public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public int? HospitalId { get; set; }
        public virtual Hospital? Hospital { get; set; }
        public Role Role { get; set; }
    }
}
