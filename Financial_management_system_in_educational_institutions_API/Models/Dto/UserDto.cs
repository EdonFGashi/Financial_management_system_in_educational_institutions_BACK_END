    using System.ComponentModel.DataAnnotations;

namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string City { get; set; }
        public DateTime BrirthDate { get; set; }
        public char Gender { get; set; }
    }
}
