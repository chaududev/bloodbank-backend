using Domain.Model.BloodRegister;
using Infrastructure.Data;
using Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repository
{
	public class ChartRepository : IChartRepository
	{
		private readonly ApplicationDbContext db;

		public ChartRepository(ApplicationDbContext db)
		{
			this.db = db;
		}

		public IEnumerable<object> GetBloodGroupStatistics(DateTime fromDate, DateTime toDate)
		{
			var statistics = db.Registers.Where(e => e.TimeSign >= fromDate && e.TimeSign <= toDate).Include(e=>e.BloodGroup)
			.GroupBy(e => e.BloodGroup.Name)
			.Select(group => new {
				BloodGroup = group.Key,
				Count = group.Count(),
				TotalMl = group.Sum(register => register.Ml)
			})
			.ToList();

			return statistics.Cast<object>().ToList();
		}

		public IEnumerable<object> GetDateStatistics(DateTime fromDate, DateTime toDate)
		{
			var statistics = db.Registers.Where(e => e.TimeSign >= fromDate && e.TimeSign <= toDate)
            .GroupBy(e => e.TimeSign.Date)
			.Select(group => new {
				Date = group.Key,
				Count = group.Count(),
				TotalMl = group.Sum(register => register.Ml)
			})
			.ToList();
			return statistics.Cast<object>().ToList();
		}
		public IEnumerable<object> GetHospitalStatistics(DateTime fromDate, DateTime toDate)
		{
			var statistics = db.Registers.Where(e => e.TimeSign >= fromDate && e.TimeSign <= toDate).Include(e => e.Hospital)
			.GroupBy(e => e.Hospital.Name)
			.Select(group => new {
				Hospital = group.Key,
				Count = group.Count(),
				TotalMl = group.Sum(register => register.Ml)
			})
			.ToList();

			return statistics.Cast<object>().ToList();
		}
	}
}
