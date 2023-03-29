using Application.IService;
using Domain.ValueObject;
using Infrastructure.IRepository;

namespace Application.Service
{
	public class ChartService : IChartService
	{
		readonly IChartRepository repository;

		public ChartService(IChartRepository repository)
		{
			this.repository = repository;
		}

		public IEnumerable<BloodChart> GetBloodGroupStatistics(DateTime? fromDate, DateTime? toDate)
		{
			return repository.GetBloodGroupStatistics(fromDate??DateTime.MinValue,toDate??DateTime.MaxValue);
		}

		public IEnumerable<DateChart> GetDateStatistics(DateTime? fromDate, DateTime? toDate)
		{
			return repository.GetDateStatistics(fromDate ?? DateTime.MinValue, toDate ?? DateTime.MaxValue);
		}

		public IEnumerable<HospitalChart> GetHospitalStatistics(DateTime? fromDate, DateTime? toDate)
		{
			return repository.GetHospitalStatistics(fromDate ?? DateTime.MinValue, toDate ?? DateTime.MaxValue);
		}
	}
}
