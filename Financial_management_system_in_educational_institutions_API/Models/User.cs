namespace Financial_management_system_in_educational_institutions_API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int PersonalNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string City { get; set; }
        public DateTime BrirthDate { get; set; }
        public char Gender { get; set; }
    }
}
