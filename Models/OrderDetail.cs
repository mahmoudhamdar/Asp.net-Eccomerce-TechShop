using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }
        public Order Order { get; set; } = new();

        public int ProductID { get; set; }
        public Product Product { get; set; } = new();
    }
}