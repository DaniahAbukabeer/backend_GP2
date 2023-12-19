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
        public ViewResult AddStock(int PharmacyId)
        {
            ViewData["PharmacyId"] = PharmacyId;

            var viewmodel = new AddStockViewModel { PharmacyId = PharmacyId };

            return View(viewmodel);
        }
        //[HttpPost]
        //public IActionResult AddStock(Product product)
        //{
        //   if (ModelState.IsValid)
        //    {
        //        Product NewProduct = _product.addProduct(product);

        //        //var pharamcyId = _pharmacy.GetPharmacy();
        //        return RedirectToAction("Index", NewProduct);
        //    }
        //    return View();
        //}
        
        [HttpPost]
        public IActionResult AddStock(AddStockViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Product NewProduct = _product.addProduct(product);
                //int pharamcyId = model.PharmacyId;

                Product NewProduct = new Product { 
                    Id = model.ProductId,
                    TName = model.TName,
                    SName = model.SName,
                    Provider= model.Provider,
                    Country = model.Country,
                    Dosage = model.Dosage,
                    ATCCODE = model.ATCCODE,
                    PharmaysProducts = new List<PharmaysProducts> { new PharmaysProducts()
                    {
                        PublicPrice = model.PublicPrice,
                        Quantity = model.Quantity,
                        Amount= model.Amount,
                        PrivatePrice = model.PrivatePrice,
                        PharmacyId = model.PharmacyId,
                        ProductId = model.ProductId,
                    } }
                };

                _product.addProduct(NewProduct);
               

                //var pharamcyId = _pharmacy.GetPharmacy();
                return RedirectToAction("Index", NewProduct);
            }
            return View(model);
        }


        [HttpGet]
        public ViewResult EditStock(int PharmacyId)
        {
            //var Pharmacyy = _pharmacy.GetPharmacy(Id);

            var Stock = _product.GetProducts().Where(e => e.PharmaysProducts.Any(ps => ps.PharmacyId == PharmacyId));


            //var PharmacyStock = _product.GetProducts()
            //    .Select(product => new
            //    {
            //        Product = product,
            //        PharmaysProducts = product.PharmaysProducts
            //    })
            //    .Where(e => e.PharmaysProducts.Any(ps => ps.PharmacyId == PharmacyId))
            //    .Select(e => e.Product);

            //var prodctPharmacy = _product.GetProduct(id=> id new { e=>e })
            if (Stock.Any())
                foreach (var pro in Stock)
                    Console.WriteLine($"----------found product {pro.SName} that belongs to pharmacy with Id {PharmacyId}------------");
            else
                Console.WriteLine($"-----------------Stock didnt get any data.... AGAIN!!--------------------");
            //Console.WriteLine($"the routed Pharmacy Id is {PharmacyId}");
            var AllStock = _product.GetProducts();
            //    .Where(e => e.PharmaysProducts.Any(ps => ps.PharmacyId == PharmacyId))
            //    .ToList<Product>();
            // Eager loading example
            //var AllStock = _product.GetProducts()
            //    .Include(p => p.PharmaysProducts)
            //    .Where(e => e.PharmaysProducts.Any(ps => ps.PharmacyId == Id));


            //var viewModel = new PharmacyProductsViewModel
            //{
            //    Pharmacy = Pharmacyy,
            //    Products = AllStock,

            //};
            //return View(viewModel);
            return View(AllStock);
        }

        [HttpPost]
        public IActionResult EditStock(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        [HttpPost]
        public IActionResult DeletePharmacy(int Id)
        {
            Pharmacy ToDelete = _pharmacy.GetPharmacy(Id);
            if (ToDelete != null) {
                _pharmacy.DeletePharmacy(Id);
                
            }

            return RedirectToAction("Index");
        
        
        }
    }
}
