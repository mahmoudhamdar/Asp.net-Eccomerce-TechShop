
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Areas.Customer.Models;
using WebApplication1.Models;
using IdentityUser = Microsoft.AspNet.Identity.EntityFramework.IdentityUser;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                { ProductID = 1, Name = "Razer Headphones", Description = "", Price = 30, ImgUrl = "", CategoryId = 3 },
                new Product
                { ProductID = 2, Name = "HyperX Mouse", Description = "", Price = 110, ImgUrl = "", CategoryId = 2 },
                 new Product
                 { ProductID = 3, Name = "Razor Keyboard", Description = "", Price = 70, ImgUrl = "", CategoryId = 1 },
                 new Product
                     { ProductID = 4, Name = "Razor Headphones2", Description = "", Price = 30, ImgUrl = "", CategoryId = 3 },
                 new Product
                     { ProductID = 5, Name = "HyperX Mouse2", Description = "", Price = 110, ImgUrl = "", CategoryId = 2 },
                 new Product
                     { ProductID = 6, Name = "Razor Keyboard2", Description = "", Price = 70, ImgUrl = "", CategoryId = 1 },
                 new Product
                     { ProductID = 7, Name = "Razor Headphones2", Description = "", Price = 30, ImgUrl = "", CategoryId = 3 },
                 new Product
                     { ProductID = 8, Name = "HyperX Mouse2", Description = "", Price = 110, ImgUrl = "", CategoryId = 2 },
                 new Product
                     { ProductID = 9, Name = "Razor Keyboard2", Description = "", Price = 70, ImgUrl = "", CategoryId = 1 }
            );
            modelBuilder.Entity<Category>().HasData(
              new Category
              { CategoryId = 1, Name = "Keyboards", DisplayOrder = 1, CreatedDateTime = DateTime.Now.Date },
              new Category
              { CategoryId = 2, Name = "Mouses", DisplayOrder = 2, CreatedDateTime = DateTime.Now.Date },
               new Category
               { CategoryId = 3, Name = "Headphones", DisplayOrder = 3, CreatedDateTime = DateTime.Now.Date }
          );
            modelBuilder.Entity<Company>().HasData(
                new Company
                    { CompanyId = 1, Name = "Razor", PhoneNumber = "01334455",City = "Beirut",StreetAddress = ""},
                new Company
                    { CompanyId = 2, Name = "HyperX", PhoneNumber = "05557878",City = "Tyre",StreetAddress = "" },
                new Company
                    { CompanyId = 3, Name = "Legion", PhoneNumber = "02123599",City = "Saida",StreetAddress = "" }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                    { UserName ="Admin" , PhoneNumber = "01334455",Email = "Beirut",Address = "Beirut"},
                new User
                    { UserName = "Customer",  PhoneNumber = "05557878",Email = "Tyre",Address = "Tyre" }
               
            ); 
           
            
        }
      

    }
}