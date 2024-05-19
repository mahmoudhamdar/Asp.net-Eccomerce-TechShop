using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Models;
namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                { ProductID = 1, Name = "Razer Headphones", Description = "", Price = 30, ImgUrl = "", CategoryId = 3 },
                new Product
                { ProductID = 2, Name = "HyperX Mouse", Description = "", Price = 110, ImgUrl = "", CategoryId = 2 },
                 new Product
                 { ProductID = 3, Name = "Razor Keyboard", Description = "", Price = 70, ImgUrl = "", CategoryId = 1 }
            );
            modelBuilder.Entity<Category>().HasData(
              new Category
              { CategoryId = 1, Name = "Keyboards", DisplayOrder = 1, CreatedDateTime = DateTime.Now.Date },
              new Category
              { CategoryId = 2, Name = "Mouses", DisplayOrder = 2, CreatedDateTime = DateTime.Now.Date },
               new Category
               { CategoryId = 3, Name = "Headphones", DisplayOrder = 3, CreatedDateTime = DateTime.Now.Date }
          );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}