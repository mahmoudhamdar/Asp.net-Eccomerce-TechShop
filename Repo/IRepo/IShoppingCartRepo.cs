using WebApplication1.Areas.Customer.Models;

namespace WebApplication1.Repo.IRepo;

public interface IShoppingCartRepo : IRepo<ShoppingCart>
{
    void Update(ShoppingCart shoppingCart);
}