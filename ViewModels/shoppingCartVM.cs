using WebApplication1.Areas.Admin.Models;
using WebApplication1.Areas.Customer.Models;

namespace WebApplication1.ViewModels;

public class shoppingCartVM
{
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
   
    public OrderHeader OrderHeader { get; set; }
}