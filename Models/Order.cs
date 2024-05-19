using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }

        public int UserID { get; set; }
        public User User { get; set; } = new();

        public List<OrderDetail> OrderDetails { get; set; } = new();


    }
}