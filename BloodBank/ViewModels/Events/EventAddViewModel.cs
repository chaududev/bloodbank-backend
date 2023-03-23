using Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.ViewModels.Events
{
    public class EventAddViewModel
    {
        [MaxLength(50, ErrorMessage = "{0} can have a max of {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string EventName { get; set; }
        [MaxLength(100, ErrorMessage = "{0} can have a max of {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Content { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date format. The correct format is yyyy-mm-dd.")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid Date format. The correct format is yyyy-mm-dd.")]
        [Required(ErrorMessage = "{0} is required")]
        public DateTime EndTime { get; set; }
        [EnumDataType(typeof(EventStatus), ErrorMessage = "{0} must be between 0 and 4")]
        public EventStatus Status { get; set; }
    }
}
