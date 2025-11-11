using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Models;

namespace WebApplication1.Areas.Customer.Models;

public class ShoppingCart
{
    
    public int Id { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }
    [Range(1,100,ErrorMessage = "Cannot Have More Than 100 Items in your Cart")]
    public int count { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public User User { get; set; }
    [NotMapped]
    public double Price { get; set; }
}