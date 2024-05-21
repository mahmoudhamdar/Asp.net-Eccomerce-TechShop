using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repo;
using WebApplication1.Repo.IRepo;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitofwork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //Constuctor
        public ProductController(IUnitofwork unitofwork,IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitofwork = unitofwork;
        }
        //Index
        public IActionResult Index()
        {
            List<Product> objProductList = _unitofwork.productRepo.GetAll(includeProperties:"Category").ToList();

            return View(objProductList);
        }
        //Details
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
        //Update Or Add
        public IActionResult ProductUpsert(int? id)
        {
            ProductVM productVm = new ProductVM()
            {
                CategoryList    = _unitofwork.categoryRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }),
                Product = new Product()
            };
            //Add
            if (id == null || id == 0)
            {
                return View(productVm);
            }
            //Update
            else
            {
                productVm.Product = _unitofwork.productRepo.Get(u => u.ProductID == id);
                return View(productVm);
            }
           
        }
        [HttpPost]
        public IActionResult ProductUpsert(ProductVM productVm,IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file!=null)
                {
                    string filename = Guid.NewGuid().ToString()+Path.GetExtension((file.FileName));
                    string productPath = Path.Combine(wwwRootPath,@"images\product");
                    if (string.IsNullOrEmpty(productVm.Product.ImgUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVm.Product.ImgUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                            System.IO.File.Delete(oldImagePath);
                    }
                    using (var fileStream=new FileStream(Path.Combine(productPath,filename),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVm.Product.ImgUrl = @"\images\product" + filename;
                }

                if (productVm.Product.ProductID==0)
                {
                    _unitofwork.productRepo.Add(productVm.Product);
                }
                else
                {
                    _unitofwork.productRepo.Update(productVm.Product);
                }
                _unitofwork.productRepo.Add(productVm.Product);
                _unitofwork.Save();
                TempData["success"] = "A new " + productVm.Product.Name + " is Added";
                return RedirectToAction("Index");
            }
            else
            {
                productVm.CategoryList = _unitofwork.categoryRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                });
                return View();
            }

            
        }
      
        //Remove a product
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

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> ProductList = _unitofwork.productRepo.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = ProductList });
        }

    }
}