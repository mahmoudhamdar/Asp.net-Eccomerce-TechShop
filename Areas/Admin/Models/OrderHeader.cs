using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Models;

public class OrderHeader
{
    public int Id { get; set; }
    public string UserName { get; set; }
    [ForeignKey(("UserId"))]
    [ValidateNever]
    public User User { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippingDate { get; set; }
    public double OrderTotal { get; set; }
    
    public string? Orderstatus { get; set; }
    public string? PaymentStatus { get; set; }
    public string? TrackingNumber { get; set; }
    public string? Carrier { get; set; }
    
    public DateTime PaymentDate { get; set; }
    public DateOnly PaymentDueDate { get; set; }
    
    public string? PaymentIntentId { get; set; }
   
     
    [Required]
    public string PhoneNumber { get; set; } 
    [Required]
    public string? Address { get; set; } 
}