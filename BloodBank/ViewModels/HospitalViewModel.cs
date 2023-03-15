using Domain.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels
{
    public class HospitalViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public virtual List<User>? Users { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
