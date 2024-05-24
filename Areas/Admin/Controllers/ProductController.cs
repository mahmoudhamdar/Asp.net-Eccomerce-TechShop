using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Models;

using WebApplication1.Repo;
using WebApplication1.Repo.IRepo;
using WebApplication1.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utility.Utility.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly IUnitofwork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //Constructor
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
       
       
        //Update Or Add
        public IActionResult ProductUpsert(int? id)
        {
            ProductVM productVm = new ()
            {
                CategoryList    = _unitofwork.categoryRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }).ToList(),
                Product = new ()
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
                    string filename = Guid.NewGuid()+Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath,@"images\product\");
                    if (!string.IsNullOrEmpty(productVm.Product.ImgUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, productVm.Product.ImgUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                            System.IO.File.Delete(oldImagePath);
                    }
                    using (var fileStream=new FileStream(Path.Combine(productPath,filename),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVm.Product.ImgUrl = @"\images\product\" + filename;
                }

                if (productVm.Product.ProductID==0)
                {
                    if (productVm.Product.CategoryId==0)
                    {
                        
                    }
                    productVm.Product.CategoryId = 1;
                    _unitofwork.productRepo.Add(productVm.Product);
                    TempData["success"] =   "A new " + productVm.Product.Name + " is Added";
                }
                else
                {
                    _unitofwork.productRepo.Update(productVm.Product);
                    TempData["success"] = productVm.Product.Name + " is Updated";
                }
               
                _unitofwork.Save();
              
                return RedirectToAction("Index");
            }
          
               
            return View(productVm);
            

            
        }
      
        //Remove a product
        public IActionResult ProductRemove(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Product? productfromdb = _unitofwork.productRepo.Get(p =>  p.ProductID == id,includeProperties:"Category");
           

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