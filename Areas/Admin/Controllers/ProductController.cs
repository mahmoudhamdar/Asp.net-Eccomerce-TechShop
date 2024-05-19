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
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitofwork _unitofwork;

        public ProductController(IUnitofwork unitofwork)
        {

            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitofwork.productRepo.GetAll().ToList();

            return View(objProductList);
        }
        public IActionResult ProductDetails(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Product? product = _unitofwork.productRepo.Get(p => p.ProductID == id);
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

            if (ModelState.IsValid)
            {

                _unitofwork.productRepo.Add(product);
                _unitofwork.Save();
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
            Product? productfromdb = _unitofwork.productRepo.Get(u => u.ProductID == id);
            if (productfromdb == null)
                NotFound();
            return View(productfromdb);
        }
        [HttpPost]
        public IActionResult ProductEdit(Product pr)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.productRepo.Update(pr);
                _unitofwork.Save();
                TempData["success"] = pr.Name + " is Updated";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ProductRemove(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Product? productfromdb = _unitofwork.productRepo.Get(p =>  p.ProductID == id);
           

            return View(productfromdb);
        }
        [HttpPost]
        public IActionResult ProductRemove(Product pr)
        {
            _unitofwork.productRepo.Remove(pr);
            _unitofwork.Save();
            TempData["success"] = pr.Name + " is Removed";
            return RedirectToAction("Index");
        }

    }
}