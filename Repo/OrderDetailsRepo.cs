using WebApplication1.Areas.Admin.Models;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo;

public class OrderDetailsRepo:Repo<OrderDetails>, IOrderDetails
{
    private ApplicationDbContext _db;
    public OrderDetailsRepo(ApplicationDbContext db) : base(db)
    {
        _db = db;

    }

    public void Update(OrderDetails orderDetails)
    {
        _db.Update(orderDetails);
    }
}