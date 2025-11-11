using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Models;

public class OrderDetails
{
    public int Id {  get; set; }
    [Required]
    public int OrderHeaderId {  get; set; }
    [ForeignKey("OrderHeaderId")]
    [ValidateNever]
    public OrderHeader OrderHeader { get; set; }

    [Required]
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
}