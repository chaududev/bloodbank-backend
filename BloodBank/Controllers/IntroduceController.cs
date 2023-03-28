using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class IntroduceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
