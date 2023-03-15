using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Posts;
using Domain.Model.Base;
using System.Drawing;

namespace BloodBank.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; private set; }
        [Required(ErrorMessage = "EventName is required")]
        public string EventName { get;  set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get;  set; }
        [Required(ErrorMessage = "Content is required")]
        public string Content { get;  set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date format. The correct format is yyyy-mm-dd.")]
        public DateTime StartTime { get;  set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date format. The correct format is yyyy-mm-dd.")]
        public DateTime EndTime { get;  set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Status must be between 0 and 4")]
        public Status Status { get; set; }
        [ForeignKey("Image")]
        public int ImageId { get; private set; }
        public virtual Image? Image { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
