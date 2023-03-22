using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class HospitalController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
