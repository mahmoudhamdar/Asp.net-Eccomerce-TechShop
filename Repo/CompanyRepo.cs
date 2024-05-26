using WebApplication1.Areas.Admin.Models;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo;

public class CompanyRepo : Repo<Company>, ICompanyRepo
{
    private ApplicationDbContext _db;
    public CompanyRepo(ApplicationDbContext db) : base(db)
    {
        _db = db;

    }

    public void Update(Company company)
    {
        _db.Update(company);
    }

   
}