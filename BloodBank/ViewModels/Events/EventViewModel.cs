using BloodBank.ViewModels.Images;

namespace BloodBank.ViewModels.Events
{
    public class EventViewModel : EventAddViewModel
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public ImageViewModel Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
