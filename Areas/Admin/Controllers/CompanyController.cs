
using Microsoft.AspNetCore.Mvc;

using WebApplication1.Areas.Admin.Models;

using WebApplication1.Repo.IRepo;

namespace WebApplication1.Areas.Admin.Controllers;



[Area("Admin")]
public class CompanyController:Controller
{

    private readonly IUnitofwork _unitOfwork;
    public CompanyController(IUnitofwork unitofwork)
    {
        _unitOfwork = unitofwork;
    }


    public IActionResult Index()
    {

        List<Company> companyList = _unitOfwork.companyRepo.GetAll().ToList();

            return View(companyList);
        
    }
      public IActionResult CompanyUpsert(int? id)
        {
         
            //Add
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            //Update
            else
            {
                Company company = _unitOfwork.companyRepo.Get(u => u.CompanyId == id);
                return View(company);
            }
           
        }
        [HttpPost]
        public IActionResult CompanyUpsert(Company company)
        {

            if (ModelState.IsValid)
            {
                if (company.CompanyId==0)
                {
                     
                    _unitOfwork.companyRepo.Add(company);
                    TempData["success"] =   "A new " + company.Name + " is Added";
                }
                else
                {
                    _unitOfwork.companyRepo.Update(company);
                    TempData["success"] = company.Name + " is Updated";
                }
               
                _unitOfwork.Save();
              
                return RedirectToAction("Index");
            }
            return View(company);
            
        }
    
    
        public IActionResult CompanyRemove(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Company companyfromdb = _unitOfwork.companyRepo.Get(p =>  p.CompanyId == id,includeProperties:"Category");
           

            return View(companyfromdb);
        }
        [HttpPost]
        public IActionResult CompanyRemove(Company company)
        {
            _unitOfwork.companyRepo.Remove(company);
            _unitOfwork.Save();
            TempData["success"] = company.Name + " is Removed";
            return RedirectToAction("Index");
        }
    
    
    
    
    
    
    
    
}