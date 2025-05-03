using Microsoft.AspNetCore.Identity;

namespace Financial_management_system_in_educational_institutions_API.Models.Identity
{
    public class AppUser : IdentityUser { }
    public class AppRole : IdentityRole { }
    public class AppUserClaim : IdentityUserClaim<string> { }
    public class AppUserLogin : IdentityUserLogin<string> { }
    public class AppUserRole : IdentityUserRole<string> { }
    public class AppRoleClaim : IdentityRoleClaim<string> { }
    public class AppUserToken : IdentityUserToken<string> { }
}
