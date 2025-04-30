using System.Globalization;

namespace MovieAPI.DTOs
{
    public class UsersDTO
    {
        public string Id { get; set; } //Id e perdoruesit
        public string Email { get; set; } //emaili i perdoruesit
        public string Role { get; set; } //roli i perdoruesit (admin, user, etj)
    }
}
