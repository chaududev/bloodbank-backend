using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
