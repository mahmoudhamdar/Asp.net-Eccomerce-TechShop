using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Details(int? id)
    {
        Product product = _unitofwork.productRepo.Get(p=>p.ProductID==id);
        return View(product);
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
