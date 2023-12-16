using Microsoft.AspNetCore.Mvc;
using WebAppTry1.Models;
using WebAppTry1.Models.Interfaces;

namespace WebAppTry1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductReopsitory _product;

        public ProductController(IProductReopsitory product)
        {
            _product = product;
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
