using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Areas.Admin.Models;

public class Company
{
    [Key]
    public int CompanyId { get; set; }
    [Required] public string Name { get; set; }="";
    public string StreetAddress { get; set; } = "";
    public string City { get; set; } = "";
    public string PhoneNumber  { get;set; }= "";



}