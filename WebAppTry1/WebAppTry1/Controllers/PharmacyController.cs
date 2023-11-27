using Microsoft.AspNetCore.Mvc;
using WebAppTry1.Models;

namespace WebAppTry1.Controllers
{
    public class PharmacyController : Controller
    {
        public PharmacyController()
        {

        }
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AddStock()
        {
            return View();
        }

        [HttpGet]
        public ViewResult EditStock()
        {
            return View();
        }

        public ViewResult Selling() { 
            return View();
        }
        [HttpGet]
        public ViewResult Receipt()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AddPharmacy() {
            return View();
        }

        [HttpPost]
        public IActionResult AddPharmacy(Pharmacy pharmacy)
        {
            Pharmacy newPharmacy = 

            return View();
        }
    }
}
