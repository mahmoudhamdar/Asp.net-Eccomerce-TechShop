using WebApplication1.Models;

namespace WebApplication1.Repo.IRepo;

public interface IUserRepo:IRepo<User>
{
    public void Update(User user);
}