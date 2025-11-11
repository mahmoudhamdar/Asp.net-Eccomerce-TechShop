using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Repo.IRepo;

public interface IOrderDetails:IRepo<OrderDetails>
{
    void Update(OrderDetails orderDetails);
}