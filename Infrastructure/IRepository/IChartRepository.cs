

namespace Infrastructure.IRepository
{
	public interface IChartRepository
	{
		IEnumerable<object> GetBloodGroupStatistics(DateTime fromDate, DateTime toDate);
		IEnumerable<object> GetDateStatistics(DateTime fromDate, DateTime toDate);
		IEnumerable<object> GetHospitalStatistics(DateTime fromDate, DateTime toDate);
	}
}
