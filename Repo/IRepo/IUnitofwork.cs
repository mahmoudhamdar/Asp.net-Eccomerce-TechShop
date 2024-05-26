using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repo.IRepo
{
    public interface IUnitofwork
    {
        public ICategoryRepo categoryRepo { get;  }
        public  IProductRepo productRepo { get; }
        public ICompanyRepo companyRepo { get; }
        public IShoppingCartRepo ShoppingCartRepo { get; }
        public IUserRepo UserRepo { get; }
        public IOrderHeader OrderHeader { get; }
        public IOrderDetails OrderDetails { get; }
        void Save();
    }
}