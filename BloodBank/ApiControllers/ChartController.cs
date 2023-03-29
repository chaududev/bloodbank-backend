using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace UI.ApiControllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ChartController : ControllerBase
	{
		readonly IChartService chartService;

		public ChartController(IChartService chartService)
		{
			this.chartService = chartService;
		}
		[HttpGet("Blood")]
		public IActionResult GetBlood(DateTime? fromDate, DateTime? toDate)
		{
			try
			{
				var statistics = chartService.GetBloodGroupStatistics(fromDate,toDate);

				return Ok(statistics);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpGet("Date")]
		public IActionResult GetDate(DateTime? fromDate, DateTime? toDate)
		{
			try
			{
				var statistics = chartService.GetDateStatistics(fromDate,toDate);

				return Ok(statistics);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpGet("Hospital")]
		public IActionResult GetHospital(DateTime? fromDate, DateTime? toDate)
		{
			try
			{
				var statistics = chartService.GetHospitalStatistics(fromDate,toDate);

				return Ok(statistics);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
