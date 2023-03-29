using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
	public interface IChartService
	{
		IEnumerable<object> GetBloodGroupStatistics(DateTime? fromDate, DateTime? toDate);
		IEnumerable<object> GetDateStatistics(DateTime? fromDate, DateTime? toDate);
		IEnumerable<object> GetHospitalStatistics(DateTime? fromDate, DateTime? toDate);
	}
}
