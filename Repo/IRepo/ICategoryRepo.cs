using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Repo.IRepo
{
    public interface ICategoryRepo : IRepo<Category>
    {
        void Update(Category category);

    }
}