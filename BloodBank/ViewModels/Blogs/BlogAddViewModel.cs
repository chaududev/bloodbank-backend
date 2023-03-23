using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels.Blogs
{
    public class BlogAddViewModel
    {
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string Title { get; set; }
        [MaxLength(100, ErrorMessage = "{0} can have a max of {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Content { get; set; }
    }
}
