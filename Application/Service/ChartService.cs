using Application.IService;
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

		public IEnumerable<object> GetBloodGroupStatistics(DateTime? fromDate, DateTime? toDate)
		{
			return repository.GetBloodGroupStatistics(fromDate??DateTime.MinValue,toDate??DateTime.MaxValue);
		}

		public IEnumerable<object> GetDateStatistics(DateTime? fromDate, DateTime? toDate)
		{
			return repository.GetDateStatistics(fromDate ?? DateTime.MinValue, toDate ?? DateTime.MaxValue);
		}

		public IEnumerable<object> GetHospitalStatistics(DateTime? fromDate, DateTime? toDate)
		{
			return repository.GetHospitalStatistics(fromDate ?? DateTime.MinValue, toDate ?? DateTime.MaxValue);
		}
	}
}
