using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                { ProductID = 1, Name = "Razer Headphones", Description = "", Price = 30 },
                new Product
                { ProductID = 2, Name = "HyperX Mouse", Description = "", Price = 110 },
                 new Product
                 { ProductID = 3, Name = "Razor Keyboard", Description = "", Price = 70 }
            );
        }
        public DbSet<Product> Products { get; set; }
        
    }
}