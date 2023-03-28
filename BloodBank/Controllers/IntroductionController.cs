using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class IntroductionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
