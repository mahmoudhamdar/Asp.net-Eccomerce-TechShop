using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;

namespace WebApplication1.Repo
{
    public class UnitOfwork : IUnitofwork
    {
        private ApplicationDbContext _db;
        public IProductRepo productRepo { get; private set; }
        public ICategoryRepo categoryRepo { get; set; }
        public UnitOfwork(ApplicationDbContext db)
        {
            _db = db;
            productRepo = new ProductRepo(_db);
            categoryRepo = new CategoryRepo(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}