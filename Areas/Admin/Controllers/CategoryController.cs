
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utility.Utility.Role_Admin)]
    public class CategoryController : Controller
    {
        public IUnitofwork _unitofwork;

        public CategoryController(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {

            List<Category> objCategoryList = _unitofwork.categoryRepo.GetAll().ToList();

            return View(objCategoryList);
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
           
            
            if (ModelState.IsValid)
            {

                _unitofwork.categoryRepo.Add(category);
                _unitofwork.Save();
                TempData["success"] = "A new " + category.Name + " is Added";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryfromdb = _unitofwork.categoryRepo.Get(u => u.CategoryId == id);
            
            return View(categoryfromdb);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.categoryRepo.Update(category);
                _unitofwork.Save();
                TempData["success"] = category.Name + " is Updated";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult CategoryRemove(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category? productfromdb = _unitofwork.categoryRepo.Get(p => p.CategoryId == id);
          
            return View(productfromdb);
        }
        [HttpPost]
        public IActionResult CategoryRemove(Category category)
        {
            _unitofwork.categoryRepo.Remove(category);
            _unitofwork.Save();
            TempData["success"] = category.Name + " is Removed";
            return RedirectToAction("Index");
        }

    }
}