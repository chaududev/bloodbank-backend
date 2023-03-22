using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
