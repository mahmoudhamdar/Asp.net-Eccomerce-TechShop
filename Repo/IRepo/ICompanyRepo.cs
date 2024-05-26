using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Repo.IRepo;

public interface ICompanyRepo : IRepo<Company>
{
    void Update(Company company);

}