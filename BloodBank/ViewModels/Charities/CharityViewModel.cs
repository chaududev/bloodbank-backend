using BloodBank.ViewModels.Images;

namespace BloodBank.ViewModels.Charities
{
    public class CharityViewModel : CharityAddViewModel
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public ImageViewModel Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
