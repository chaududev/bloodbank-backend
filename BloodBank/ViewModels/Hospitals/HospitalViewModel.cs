namespace BloodBank.ViewModels.Hospitals
{
    public class HospitalViewModel : HospitalAddViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
