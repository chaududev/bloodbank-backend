using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels
{
    public class BloodGroupViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Descriptiom is required")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
