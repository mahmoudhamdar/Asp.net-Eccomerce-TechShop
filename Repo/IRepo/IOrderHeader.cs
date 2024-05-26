using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Repo.IRepo;

public interface IOrderHeader:IRepo<OrderHeader>
{
    void Update(OrderHeader orderHeader);

}