using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Shipping
    {
        public int ShippingID { get; set; }
        public string Address { get; set; } = "";
        public DateTime Date { get; set; }
        public string Status { get; set; } = "";

        public int OrderID { get; set; }
        public Order Order { get; set; } = new();
    }
}