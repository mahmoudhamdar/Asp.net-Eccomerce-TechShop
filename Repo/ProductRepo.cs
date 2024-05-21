using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var objFromdb = _db.Products.FirstOrDefault(u => u.ProductID == product.ProductID);
            if (objFromdb!=null)
            {
                objFromdb.ProductID = product.ProductID;
                objFromdb.Name = product.Name;
                objFromdb.Description = product.Description;
                objFromdb.Price = product.Price;
                objFromdb.CategoryId = product.CategoryId;
                if (product.ImgUrl!=null)
                {
                    objFromdb.ImgUrl = product.ImgUrl;
                }
            }
        }
    }
}