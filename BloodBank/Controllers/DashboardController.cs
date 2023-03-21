using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
