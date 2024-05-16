using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repo.IRepo
{
    public interface IProductRepo : IRepo<Product>
    {
        void Update(Product product);
        void save();
    }
}