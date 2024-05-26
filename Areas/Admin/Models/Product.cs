using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public double Price { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; } = "";
       [ValidateNever]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; } 
    }
    
}