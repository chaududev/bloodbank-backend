using BloodBank.ViewModels.BloodGroups;
using BloodBank.ViewModels.Hospitals;
using BloodBank.ViewModels.Images;
using BloodBank.ViewModels.Users;

namespace BloodBank.ViewModels.Registers
{
    public class RegisterViewModel : RegisterAddViewModel
    {
        public int Id { get;  set; }
        public BloodGroupViewModel BloodGroup { get;  set; }
        public UserViewModel User { get; set; }
        public HospitalViewModel Hospital { get; set; }
        public int QR { get; set; }
        public ImageViewModel Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
