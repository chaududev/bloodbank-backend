using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class BloodGroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
