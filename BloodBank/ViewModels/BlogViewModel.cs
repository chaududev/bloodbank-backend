using Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels
{
    public class BlogViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "Name is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public int ImageId { get; private set; }
        public virtual Image? Image { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
