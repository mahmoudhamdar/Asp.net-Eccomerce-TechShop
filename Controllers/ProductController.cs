using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repo;
using WebApplication1.Repo.IRepo;
namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {

            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _productRepo.GetAll().ToList();

            return View(objProductList);
        }
        public IActionResult ProductDetails(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Product? product = _productRepo.Get(p => p.ProductID == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        public IActionResult ProductOrder()
        {
            return View();
        }
        public IActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            if (product.Name.Equals(product.Description))
            {
                ModelState.AddModelError("Name", "the Name can not be the same sa the Description");
            }
            if (ModelState.IsValid)
            {

                _productRepo.Add(product);
                _productRepo.save();
                TempData["success"] = "A new " + product.Name + " is Added";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult ProductEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productfromdb = _productRepo.Get(u => u.ProductID == id);
            if (productfromdb == null)
                NotFound();
            return View(productfromdb);
        }
        [HttpPost]
        public IActionResult ProductEdit(Product pr)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(pr);
                _productRepo.save();
                TempData["success"] = pr.Name + " is Updated";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ProductRemove(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Product? productfromdb = _productRepo.Get(p => p.ProductID == id);
            if (productfromdb == null)
                return NotFound();
            return View(productfromdb);
        }
        [HttpPost]
        public IActionResult ProductRemove(Product pr)
        {
            _productRepo.Remove(pr);
            _productRepo.save();
            TempData["success"] = pr.Name + " is Removed";
            return RedirectToAction("Index");
        }

    }
}