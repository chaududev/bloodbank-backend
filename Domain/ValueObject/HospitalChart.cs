
namespace Domain.ValueObject
{
    public class HospitalChart
    {
        public string Hospital { get; private set; }
        public int Count { get; private set; }
        public long TotalMl { get; private set; }
        public HospitalChart() { }

        public HospitalChart(string hospital, int count, long totalMl)
        {
            Hospital = hospital;
            Count = count;
            TotalMl = totalMl;
        }
    }
}
