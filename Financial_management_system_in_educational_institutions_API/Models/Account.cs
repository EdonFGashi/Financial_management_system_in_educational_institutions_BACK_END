using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    public class Account
    {
        [Key] //e caktojme qe te jet kolone si qeles primar
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //e caktojme qe te jete identity column
        public int accId { get; set; }
        public string organisationName { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string salt { get; set; }
        public int twoFAcode { get; set; }
        public DateTime twoFAtime { get; set; }
    }
}
