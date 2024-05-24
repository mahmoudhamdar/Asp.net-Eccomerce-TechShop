using Microsoft.AspNetCore.Identity;

using Microsoft.Build.Framework;

namespace WebApplication1.Models
{
    public class User:IdentityUser
    {
       [Required]
        public string Name { get; set; } = "";
        public string? Email { get; set; } = "";
       
        public string? Address { get; set; } = "";
        
     

    }
}