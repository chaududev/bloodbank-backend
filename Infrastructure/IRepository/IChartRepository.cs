
using Domain.ValueObject;

namespace Infrastructure.IRepository
{
	public interface IChartRepository
	{
		IEnumerable<BloodChart> GetBloodGroupStatistics(DateTime fromDate, DateTime toDate);
		IEnumerable<DateChart> GetDateStatistics(DateTime fromDate, DateTime toDate);
		IEnumerable<HospitalChart> GetHospitalStatistics(DateTime fromDate, DateTime toDate);
	}
}
