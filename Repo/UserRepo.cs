using System.Linq.Expressions;
using WebApplication1.Areas.Customer.Models;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo;

public class UserRepo:Repo<User>,IUserRepo
{ 
    private  ApplicationDbContext _db;
    private IUserRepo _userRepoImplementation;

    public UserRepo(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(User user)
    {
        _db.Update(user);
    }

   

   
}