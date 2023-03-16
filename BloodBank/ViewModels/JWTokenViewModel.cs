namespace BloodBank.ViewModels
{
    public class JWTokenViewModel
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public UserViewModel User {  get; set; }
    }
}
