using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
	public class TreasuryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
