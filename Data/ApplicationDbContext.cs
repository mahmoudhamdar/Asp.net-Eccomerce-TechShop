
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
                { ProductID = 1, Name = "Legion Mouse x1", Description = "", Price = 30, ImgUrl = @"\images\product\download.jpg", CategoryId = 2 },
                new Product
                { ProductID = 2, Name = "Legion Mouse x2", Description = "", Price = 110, ImgUrl = @"\images\product\download (1).jpg", CategoryId = 2 },
                 new Product
                 { ProductID = 3, Name = "Razor Keyboard K4", Description = "", Price = 70, ImgUrl = @"\images\product\https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_h61_h66_9705254158366_huntsman-v3-pro-mini-2-500x500.png", CategoryId = 1 },
                 new Product
                     { ProductID = 4, Name = "Razor Headphones Kraken", Description = "", Price = 30, ImgUrl = @"\images\product\krakens.jpg", CategoryId = 3 },
                 new Product
                     { ProductID = 5, Name = "Razor Keyboard K3", Description = "", Price = 110, ImgUrl = @"\images\product\https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_h8f_h57_9640099217438_blackwidow-v4-black-x-500x500.png", CategoryId = 1 },
                 new Product
                     { ProductID = 6, Name = "Razor Keyboard K5", Description = "", Price = 70, ImgUrl = @"\images\product\https___hybrismediaprod.blob.core.windows.net_sys-master-phoenix-images-container_hf7_h5a_9640099119134_blackwidow-v4-75-black-2-500x500.png", CategoryId = 1 },
                 new Product
                     { ProductID = 7, Name = "Razor cloudII", Description = "", Price = 30, ImgUrl = @"\images\product\headphones.jpg", CategoryId = 3 },
                 new Product
                     { ProductID = 8, Name = "HyperX Mouse PulseFire", Description = "", Price = 110, ImgUrl = @"\images\product\Hyper_mouse.jpg", CategoryId = 2 }
                 
            );
            modelBuilder.Entity<Category>().HasData(
              new Category
              { CategoryId = 1, Name = "Keyboards", DisplayOrder = 1, CreatedDateTime = DateTime.Now.Date },
              new Category
              { CategoryId = 2, Name = "Mices", DisplayOrder = 2, CreatedDateTime = DateTime.Now.Date },
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

        }
      

    }
}