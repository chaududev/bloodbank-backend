using Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels.Registers
{
    public class RegisterUpdateViewModel
    {

        [MaxLength(20, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Note { get; set; } = "None";
        [EnumDataType(typeof(Status), ErrorMessage = "{0} must be between 0 and 5")]
        [Required(ErrorMessage = "{0} is required")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public int BloodId { get; set; }
        public DateTime? TimeSign { get; set; } = DateTime.MaxValue;
        [Required(ErrorMessage = "{0} is required")]
        public int HospitalId { get; set; }
        public int? Ml { get; set; }
    }
}
