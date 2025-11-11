using WebApplication1.Areas.Customer.Models;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo;

public class ShoppingCartRepo:Repo<ShoppingCart>,IShoppingCartRepo
{
    private  ApplicationDbContext _db;
    public ShoppingCartRepo(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(ShoppingCart shoppingCart)
    {
        _db.Update(shoppingCart);
    }
}