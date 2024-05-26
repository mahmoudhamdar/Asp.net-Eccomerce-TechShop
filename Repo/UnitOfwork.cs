using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Data;
using WebApplication1.Repo.IRepo;
using WebApplication1.Areas.Admin.Models;
namespace WebApplication1.Repo
{
    public class UnitOfwork : IUnitofwork
    {
        private ApplicationDbContext _db;
        public IProductRepo productRepo { get;  }
        public ICompanyRepo companyRepo { get; }
        public ICategoryRepo categoryRepo { get;  }
        public IShoppingCartRepo ShoppingCartRepo { get; }
        public IUserRepo UserRepo { get; }
        public IOrderHeader OrderHeader { get; }
        public IOrderDetails OrderDetails { get; }
        public UnitOfwork(ApplicationDbContext db)
        {
            _db = db;
            productRepo = new ProductRepo(_db);
            categoryRepo = new CategoryRepo(_db);
            companyRepo = new CompanyRepo(_db);
            ShoppingCartRepo = new ShoppingCartRepo(_db);
            UserRepo = new UserRepo(_db);
            OrderHeader = new OrderHeaderRepo(_db);
            OrderDetails = new OrderDetailsRepo(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}