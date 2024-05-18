using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo
{
    public class CategoryRepo : Repo<Category>, ICategoryRepo
    {
        private ApplicationDbContext _db;
        public CategoryRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}