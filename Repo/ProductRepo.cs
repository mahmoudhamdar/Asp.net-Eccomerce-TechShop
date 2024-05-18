using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repo.IRepo;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Repo
{
    public class ProductRepo : Repo<Product>, IProductRepo
    {
        private ApplicationDbContext _db;
        public ProductRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}