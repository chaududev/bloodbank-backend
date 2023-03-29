
namespace Domain.ValueObject
{
    public class BloodChart
    {
        public string BloodGroup { get; private set; }
        public int Count { get; private set; }
        public long TotalMl { get; private set; }
        public BloodChart() { }

        public BloodChart(string bloodGroup, int count, long totalMl)
        {
            BloodGroup = bloodGroup;
            Count = count;
            TotalMl = totalMl;
        }
    }
}
