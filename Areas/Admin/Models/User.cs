using Microsoft.AspNetCore.Identity;

using Microsoft.Build.Framework;

namespace WebApplication1.Models
{
    public class User:IdentityUser
    {
       [Required]
        public string UserName { get; set; } 
        public string? Email { get; set; } 
        public string PhoneNumber { get; set; } 
        
        public string? Address { get; set; }
        public int? CompanyId { get; set; }


    }
}