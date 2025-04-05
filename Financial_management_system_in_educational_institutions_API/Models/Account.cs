namespace Financial_management_system_in_educational_institutions_API.Models
{
    public class Account
    {
        //kur e krijojme nje tabele
        public int accId { get; set; }
        public string organisationName { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string salt { get; set; }
        public int twoFAcode { get; set; }
        public DateTime twoFAtime { get; set; }
    }
}
