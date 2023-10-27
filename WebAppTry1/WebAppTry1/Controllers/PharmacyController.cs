using Microsoft.AspNetCore.Mvc;

namespace WebAppTry1.Controllers
{
    public class PharmacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStock()
        {
            return View();
        }
    }
}
