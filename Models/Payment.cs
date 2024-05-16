using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "";

        public int UserID { get; set; }
        public User User { get; set; } = new();

        public int OrderID { get; set; }
        public Order Order { get; set; } = new();
    }
}