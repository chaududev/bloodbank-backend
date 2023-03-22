using BloodBank.Mapper;
using Domain.Model.Base;
using Domain.Model.BloodRegister;
using Domain.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels
{
    public class RegisterBloodViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Note is required")]
        public string Note { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Status must be between 0 and 5")]
        public Status Status { get; set; }
        public int BloodId { get; set; }
        public virtual BloodGroup BloodGroup { get; private set; }
        [Required(ErrorMessage = "User is required")]
        public string UserId { get;  set; }
        public virtual User? User { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime TimeSign { get;  set; }
        public int QR { get;  set; }
        public virtual Image? Image { get; private set; }
        public int HospitalId { get;  set; }
        public virtual Hospital? Hospital { get; set; } 
    }
}
