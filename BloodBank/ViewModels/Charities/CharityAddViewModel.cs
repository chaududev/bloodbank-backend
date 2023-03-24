using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels.Charities
{
    public class CharityAddViewModel
    {
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [MaxLength(100, ErrorMessage = "{0} can have a max of {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string Situation { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Content { get; set; }
        public int? Money { get; set; } = 0;
    }
}
