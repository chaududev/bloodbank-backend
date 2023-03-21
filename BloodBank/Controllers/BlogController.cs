using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
