using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Controllers
{
    public class DocumentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
