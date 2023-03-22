using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class BloodGroupController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
