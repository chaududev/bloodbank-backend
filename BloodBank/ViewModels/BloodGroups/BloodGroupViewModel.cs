namespace BloodBank.ViewModels.BloodGroups
{
    public class BloodGroupViewModel : BloodGroupAddViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
