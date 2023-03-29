using Domain.ValueObject;
namespace Application.IService
{
	public interface IChartService
	{
		IEnumerable<BloodChart> GetBloodGroupStatistics(DateTime? fromDate, DateTime? toDate);
		IEnumerable<DateChart> GetDateStatistics(DateTime? fromDate, DateTime? toDate);
		IEnumerable<HospitalChart> GetHospitalStatistics(DateTime? fromDate, DateTime? toDate);
	}
}
