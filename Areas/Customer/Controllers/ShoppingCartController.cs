using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

    [Area("Customer")]
    [Authorize]
    public class ShoppingCartController:Controller {
      
        private  shoppingCartVM _shoppingCartVm { get; set; }
        public readonly IUnitofwork _unitofwork;

        public ShoppingCartController(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
    
    public IActionResult Index()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        _shoppingCartVm = new()
        {
            ShoppingCarts = _unitofwork.ShoppingCartRepo.GetAll(u => u.UserId == userId,
                includeProperties: "Product"),
            OrderHeader = new ()
        };
        foreach (var cart in _shoppingCartVm.ShoppingCarts)
        {
            cart.Price = cart.Product.Price;
            _shoppingCartVm.OrderHeader.OrderTotal += cart.Price*cart.count;
        }
        return View(_shoppingCartVm);
    }

    public IActionResult Plus(int id)
    {
        var cartFromDb = _unitofwork.ShoppingCartRepo.Get(c => c.Id == id);
        cartFromDb.count += 1;
        _unitofwork.ShoppingCartRepo.Update(cartFromDb);
        _unitofwork.Save();
        return RedirectToAction("Index");
    }
    public IActionResult Minus(int id){  var cartFromDb = _unitofwork.ShoppingCartRepo.Get(c => c.Id == id);
         cartFromDb.count -= 1;
             if (cartFromDb.count<1) {
                _unitofwork.ShoppingCartRepo.Remove(cartFromDb); 
                _unitofwork.Save();
             return RedirectToAction("Index");
             }
             _unitofwork.ShoppingCartRepo.Update(cartFromDb);
            _unitofwork.Save();
            return RedirectToAction("Index");}

    public IActionResult Remove(int id)
    {
        var cartFromDb = _unitofwork.ShoppingCartRepo.Get(c => c.Id == id);
       
        _unitofwork.ShoppingCartRepo.Remove(cartFromDb);
        _unitofwork.Save();
        return RedirectToAction("Index");
    }

    public IActionResult Summary()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var username = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        _shoppingCartVm = new()
        {
            ShoppingCarts = _unitofwork.ShoppingCartRepo.GetAll(u => u.UserId == username,
                includeProperties: "Product"),
            OrderHeader = new ()
        };
        _shoppingCartVm.OrderHeader.User = _unitofwork.UserRepo.Get(u => u.UserName == username);
        foreach (var cart in _shoppingCartVm.ShoppingCarts)
        {
            cart.Price = cart.Product.Price;
            _shoppingCartVm.OrderHeader.OrderTotal += cart.Price*cart.count;
        }
        return View(_shoppingCartVm);
    }

    public IActionResult PlaceOrder()
    {
        return View();
    }
   
 

    
}