using Financial_management_system_in_educational_institutions_API.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public int KomunaId { get; set; }
    public Komuna Komuna { get; set; }
}
