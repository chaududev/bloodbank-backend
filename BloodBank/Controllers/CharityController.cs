using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
	public class CharityController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
