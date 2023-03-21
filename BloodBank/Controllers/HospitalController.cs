using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
