using System.ComponentModel.DataAnnotations;

namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class LoginUserCredentials
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
