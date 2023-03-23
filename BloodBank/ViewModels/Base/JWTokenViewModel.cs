using BloodBank.ViewModels.Users;

namespace BloodBank.ViewModels.Base
{
    public class JWTokenViewModel
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public UserViewModel User { get; set; }
    }
}
