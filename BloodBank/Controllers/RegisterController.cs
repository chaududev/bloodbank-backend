using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class RegisterController : Controller
    {
        [Authorize(Policy = "Roles")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
