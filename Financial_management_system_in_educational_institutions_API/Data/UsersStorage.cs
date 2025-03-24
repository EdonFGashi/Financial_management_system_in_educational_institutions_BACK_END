using Financial_management_system_in_educational_institutions_API.Models;
using Financial_management_system_in_educational_institutions_API.Models.Dto;

namespace Financial_management_system_in_educational_institutions_API.Data
{
    public static class UsersStorage
    {
        public static List<UserDto> usersList = new List<UserDto>
        {
            new UserDto {UserId=1, FirstName = "Filan", LastName = "Fisteku", Nationality = "Shqipetar", City = "Prishtine", Gender = 'M' },
            new UserDto {UserId=2, FirstName = "Fisteke", LastName = "Filani", Nationality = "Shqipetare", City = "Skenderaj", Gender = 'F' }
        };
    }
}
