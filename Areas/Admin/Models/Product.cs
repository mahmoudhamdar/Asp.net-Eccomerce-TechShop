using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public decimal Price { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}