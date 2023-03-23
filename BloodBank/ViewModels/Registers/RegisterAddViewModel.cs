
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels.Registers
{
    public class RegisterAddViewModel : RegisterUpdateViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string UserId { get; set; }
    }
}
