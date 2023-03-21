using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
