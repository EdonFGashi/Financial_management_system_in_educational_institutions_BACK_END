using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Financial_management_system_in_educational_institutions_API.Models.Identity;

namespace Financial_management_system_in_educational_institutions_API.Models
{
    [Table("tblKomuna", Schema = "shared")]
    public class Komuna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KomunaId { get; set; }

        public string Qyteti { get; set; }

        public int? NrPopullsis { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? BuxhetiAktual { get; set; }

        public bool DitaNdarjesAuto { get; set; }

        // This user "owns" the Komuna tenant
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
