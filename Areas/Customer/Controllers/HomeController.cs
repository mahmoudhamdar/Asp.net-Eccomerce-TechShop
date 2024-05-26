using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Customer.Models;
using WebApplication1.Models;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitofwork _unitofwork;
    public HomeController(ILogger<HomeController> logger,IUnitofwork unitofwork)
    {
        _logger = logger;
        _unitofwork = unitofwork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> products = _unitofwork.productRepo.GetAll().ToList();
        return View(products);
    }
    [Authorize(Roles = Utility.Utility.Role_Customer)]
    public IActionResult Details(int id)
    {
        ShoppingCart shoppingCart = new()
        {
             Product = _unitofwork.productRepo.Get(p=>p.ProductID==id, includeProperties: "Category"),
            count= 1,
            ProductId=id
        };
        return View(shoppingCart);
    }
    [HttpPost]
    [Authorize(Roles = Utility.Utility.Role_Customer)]
    public IActionResult Details(ShoppingCart shoppingCart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
        shoppingCart.UserId = userId;

        ShoppingCart cartFromDb = _unitofwork.ShoppingCartRepo.Get(s => s.UserId == userId &&
                                                                        s.ProductId == shoppingCart.ProductId);
        if (cartFromDb==null)
        {
            _unitofwork.ShoppingCartRepo.Add(shoppingCart);
        }
        else
        {
            cartFromDb.count += shoppingCart.count;
            _unitofwork.ShoppingCartRepo.Update(cartFromDb);
        }

        TempData["success"] = "cart updated successfully";
        _unitofwork.Save();
        return RedirectToAction(nameof(Index));
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult AboutUs()
    {
        return View();
    }
}
