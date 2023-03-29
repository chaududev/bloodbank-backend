using Domain.ValueObject;
using Infrastructure.Data;
using Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class ChartRepository : IChartRepository
	{
		private readonly ApplicationDbContext db;

		public ChartRepository(ApplicationDbContext db)
		{
			this.db = db;
		}

		public IEnumerable<BloodChart> GetBloodGroupStatistics(DateTime fromDate, DateTime toDate)
		{
			var statistics = db.Registers.Where(e => e.TimeSign >= fromDate && e.TimeSign <= toDate).Include(e=>e.BloodGroup)
			.GroupBy(e => e.BloodGroup.Name)
			.Select(group => new BloodChart(
			    group.Key,
				group.Count(),
				group.Sum(register => register.Ml)
			))
			.ToList();

			return statistics;
		}

		public IEnumerable<DateChart> GetDateStatistics(DateTime fromDate, DateTime toDate)
		{
			var statistics = db.Registers.Where(e => e.TimeSign >= fromDate && e.TimeSign <= toDate)
            .GroupBy(e => e.TimeSign.Date)
			.Select(group => new DateChart (
				group.Key,
				group.Count(),
				group.Sum(register => register.Ml)
			))
			.ToList();
			return statistics;
		}
		public IEnumerable<HospitalChart> GetHospitalStatistics(DateTime fromDate, DateTime toDate)
		{
			var statistics = db.Registers.Where(e => e.TimeSign >= fromDate && e.TimeSign <= toDate).Include(e => e.Hospital)
			.GroupBy(e => e.Hospital.Name)
			.Select(group => new HospitalChart (
				group.Key,
				group.Count(),
				group.Sum(register => register.Ml)
			))
			.ToList();

			return statistics;
		}
	}
}
