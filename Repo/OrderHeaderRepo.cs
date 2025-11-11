using WebApplication1.Areas.Admin.Models;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo;

public class OrderHeaderRepo: Repo<OrderHeader>, IOrderHeader
{
    private ApplicationDbContext _db;
    public OrderHeaderRepo(ApplicationDbContext db) : base(db)
    {
        _db = db;

    }

    public void Update(OrderHeader orderHeader)
    {
        _db.Update(orderHeader);
    }
}