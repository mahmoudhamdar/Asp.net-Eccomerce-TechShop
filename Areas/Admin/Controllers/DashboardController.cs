using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Customer.Models;
using WebApplication1.Models;
using WebApplication1.Repo.IRepo;
using WebApplication1.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Utility.Utility.Role_Admin)]
    public class DashboardController : Controller
    {
        private IUnitofwork _unitofwork;

        public DashboardController(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        
        public ActionResult Index()
        {
            List<ShoppingCart> shoppingCarts = _unitofwork.ShoppingCartRepo.GetAll().ToList();
            List<User> users = _unitofwork.UserRepo.GetAll().ToList();
            DashboardVM dashboardVm = new DashboardVM();
            dashboardVm.NbofUsers = users.Count-1;
            foreach (var cart in shoppingCarts)
            {
                Product product = _unitofwork.productRepo.Get(p => p.ProductID == cart.ProductId);
                dashboardVm.UnitsSold += cart.count;
                dashboardVm.UsdollarSold += cart.count * product.Price;
                
            }
            return View(dashboardVm);
        }
        
        
        
    }
}
