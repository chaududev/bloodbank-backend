using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
	public class DashboardController : Controller
	{
        [Authorize(Policy = "AllRoles")]
        public IActionResult Index()
		{
			return View();
		}
	}
}
