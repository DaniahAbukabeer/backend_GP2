using Microsoft.AspNetCore.Mvc;
using WebAppTry1.Models;
using WebAppTry1.Models.Interfaces;

namespace WebAppTry1.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly IPharmacyRepository _pharmacy;
        private readonly IProductReopsitory _product;

        public PharmacyController(IPharmacyRepository pharmacy,IProductReopsitory product)
        {
            _pharmacy = pharmacy;
            _product = product;
        }
        public ViewResult Index()
        {
            var model = _pharmacy.GetAllPharmacy();
            return View(model);
        }

        [HttpGet]
        public ViewResult AddStock()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddStock(Product product) {
            if (ModelState.IsValid)
            {
                Product NewProduct = _product.addProduct(product);

                //var pharamcyId = _pharmacy.GetPharmacy();
                return RedirectToAction("Index",NewProduct);
            }
            return View();
        }

        [HttpGet]
        public ViewResult EditStock(int Id)
        {
            var Pharmacyy = _pharmacy.GetPharmacy(Id);
            var AllStock = _product.GetProducts();

            var viewModel = new PharmacyProductsViewModel
            {
                Pharmacy = Pharmacyy,
                Products = AllStock,

            };
            //return View(viewModel);
            return View(AllStock);
        }

        [HttpPost]
        public IActionResult EditStock(Product product)
        {
            if (ModelState.IsValid)
            {
                try { 
                    Product updatedProduct = _product.updateProduct(product);

                    if (updatedProduct != null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to Update Product");
                        return View(product);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occured while updating product");
                    return View(product);
                }
            }



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
            if (ModelState.IsValid)
            {
                Pharmacy newPharmacy = _pharmacy.AddPharmacy(pharmacy);
                //add a difrent return path if you want the user to see the new created pharmacy 
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
