using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class GettingStartedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
