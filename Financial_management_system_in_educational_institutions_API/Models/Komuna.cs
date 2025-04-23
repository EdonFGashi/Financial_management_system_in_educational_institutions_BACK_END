using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("tblKomuna")]
    public class Komuna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int komunaId { get; set; }

        public string qyteti { get; set; }

        public int nrPopullsis { get; set; }

        public decimal buxhetiAktual { get; set; }

        public bool ditaNdarjesAuto { get; set; }

        [ForeignKey("Account")]
        public int accId { get; set; }
        public Account? Account { get; set; }
    }
}
