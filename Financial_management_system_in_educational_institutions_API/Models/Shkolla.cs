using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("tblShkolla")]
    public class Shkolla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int shkollaId { get; set; }

        public string emriShkolles { get; set; }

        [ForeignKey("Person")] // Drejtori person nga tblPerson
        public int drejtori { get; set; }
        public Person? Person { get; set; }

        public string lokacioni { get; set; }
        public int nrNxenesve { get; set; }
        public decimal buxhetiAktual { get; set; }
        public bool autoNdarja { get; set; }

        [ForeignKey("Account")] // lidhet me tblAccounts
        public int accId { get; set; }
        public Account? Account { get; set; }
    }
}
