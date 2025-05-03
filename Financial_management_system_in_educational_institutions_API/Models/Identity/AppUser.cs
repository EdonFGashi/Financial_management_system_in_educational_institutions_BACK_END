using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Financial_management_system_in_educational_institutions_API.Models.Identity
{
    [Table("AspNetUsers", Schema = "shared")]
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }

        public int? KomunaId { get; set; } // Nullable for Komuna owner itself

        [ForeignKey("KomunaId")]
        public Komuna? Komuna { get; set; }
    }
    public class AppRole : IdentityRole { }
    public class AppUserClaim : IdentityUserClaim<string> { }
    public class AppUserLogin : IdentityUserLogin<string> { }
    public class AppUserRole : IdentityUserRole<string> { }
    public class AppRoleClaim : IdentityRoleClaim<string> { }
    public class AppUserToken : IdentityUserToken<string> { }
}
