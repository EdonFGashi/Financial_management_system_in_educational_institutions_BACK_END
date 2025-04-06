namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class AccountDto
    {
        public int accId { get; set; }

        public string organisationName { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        //public string salt { get; set; }
        public int twoFAcode { get; set; }
        public DateTime twoFAtime { get; set; }
    }
}
