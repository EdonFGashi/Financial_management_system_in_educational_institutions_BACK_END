
using System.ComponentModel.DataAnnotations;

namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class RegisterKomunaWithUserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; } = "Komuna";

        // Komuna fields
        [Required]
        public string Qyteti { get; set; }

        public int? NrPopullsis { get; set; }  // initially null

        public decimal? BuxhetiAktual { get; set; }  // initially null

        [Required]
        public bool DitaNdarjesAuto { get; set; }
    }
}