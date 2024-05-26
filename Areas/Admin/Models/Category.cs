using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        
        [InverseProperty("Category")]
        [ValidateNever]
        public ICollection<Product> Products { get; set; }
        
    }
}