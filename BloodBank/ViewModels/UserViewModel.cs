namespace BloodBank.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public int? HospitalId { get; set; }
    }
}
