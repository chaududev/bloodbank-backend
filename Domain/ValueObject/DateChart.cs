
namespace Domain.ValueObject
{
    public class DateChart
    {
        public DateTime Date { get;private set; }
        public int Count { get; private set; }
        public long TotalMl { get; private set; }

        public DateChart()
        {
        }

        public DateChart(DateTime date, int count, long totalMl)
        {
            Date = date;
            Count = count;
            TotalMl = totalMl;
        }
    }
}
